const { create_user, getMemberByUserID,getUserByUserId,getUsers,getUserByEmail, deleteAccount, changeEmail, changeName, changePassword, getTeamByUser_id, updateTeamName, deleteTeam, newTeam, createVerification, getVerification, clearVerification, activateAccount, newRoutine, deleteRoutine, getRoutineContent, saveRoutine, getRoutines, renameRoutine, verifyTeamAdmin, verifyTeamJoinPassword, joinTeam, getTeamJoinPassword, getTeamMembers, getTeamFullInfo, getGames} = require("./user.service");

const {genSaltSync, hashSync, compareSync} = require("bcrypt");
const { sign } = require("jsonwebtoken");
const {sendEmail} = require("./user.mailservice");
const res = require("express/lib/response");
const { strictEqual } = require("assert");
module.exports = {
//#region user control
    //tested
    testConnection: (req, res) => {
        return res.status(200).json({
            success: 1
            });
    },
    //tested
    login: (req, res) => {
        const body = req.body;
        getUserByEmail(body.email, (err, results) => {
        if (err) {
            console.log(err);
        }
        if (!results) {
            return res.status(400).json({
            success: 0,
            data: "Invalid email or password"
            });
        }
        const result = compareSync(body.password, results.password);
        if (result) {
            results.password = undefined;
            const jsontoken = sign({ result: results, email: body.email, id: results.id }, process.env.KEY, {
            expiresIn: process.env.EXPIRE
            });
            return res.status(200).json({
            success: 1,
            message: "login successfully",
            user_id: results.id,
            token: jsontoken
            });
        } else {
            return res.status(400).json({
            success: 0,
            data: "Invalid email or password"
            });
        }
        });
    },
    //tested
    createUser: (req, res) => {
      console.log(req.body.email, req.body.name, req.body.password)
      const body = req.body;
      if(body.password != undefined){
        const salt = genSaltSync(10);
        body.password = hashSync(body.password, salt);
        //erstellt user
        create_user(body, (err, results) => {
            if (err) {
                console.log(err.message);
                if(err.message.includes("ER_DUP_ENTRY"))
                {
                    return res.status(409).json({
                        success: 0,
                        message: err.message
                    });
                }

                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            const user_id = results.insertId;
            var crypto = require("crypto");
            const token = crypto.randomBytes(64).toString('hex');
            createVerification(token, user_id, (err, results) => {
              if(err){
                return res.status(500).json({
                    success: 0,
                    message: err.message
                });
              }
              else{
                  console.log(token);
                  const link = process.env.HOSTDOMAIN + "/api/account/activate/" + token;
                  sendEmail(body.email, link)
                  return res.status(200).json({
                      success: 1,
                      message: "Account created. Please check your emails!"
                  })
              }
            }
            );
        });
      }
      else{
        return res.status(400).json({
            success: 0,
            message: "Password error"
        });
      }
      
    },
    //tested
    activateAccount: (req, res) => {
        const token = req.params.token;
        getVerification(token, (err, results) => {
            if(err){
                return res.status(500).json({
                    success: 0,
                    message: "DB error"
                });
              }
              if(!results){
                return res.status(400).json({
                    success: 0,
                    message: "no account found!"
                });
              }
              else{
                const user_id = results[0].user_id
                console.log("verify:", user_id)
                activateAccount(user_id, (err, results) => {
                    if(err){
                        return res.status(500).json({
                            success: 0,
                            message: err.message
                        });
                      }
                    else if(!results){
                        return res.status(400).json({
                            success: 0,
                            message: "no account found!"
                        });
                    }
                    else{
                        clearVerification((err, results) => {
                            if(err){
                                console.log(err)
                            }
                        });
                        return res.status(200).json({
                            success: 1,
                            message: "account successfully activated!"
                        });

                    }
                });
              }
        }
        );
    },
    //tested
    verifyToken:(req, res) =>{
        return res.status(200).json({
            success: 1
        });
    },
    //not tested
    changeEmail: (req, res) => {
        const body = req.body;
          const id = req.id;
          changeEmail(body, id, (err, results) => {
              if (err) {
                  console.log(err);
                  return res.status(500).json({
                      success: 0,
                      message: "Database connection error"
                  });
              }
              return res.status(200).json({
                  success: 1,
                  data: results
              });
          });
    },
    //not tested
    changeName: (req, res) => {
      const body = req.body;
        const id = req.id;
        changeName(body, id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        });
    },
    //not tested
    changePassword: (req, res) => {
    const id = req.id;
    const body = req.body;
    if(body.password != undefined){
        const salt = genSaltSync(10);
        body.password = hashSync(body.password, salt);
        changePassword(body, id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        });
    }
    else{
        return res.status(400).json({
            success: 0,
            message: "Password error"
        });
    };
    }, 
    //tested
    deleteAccount: (req, res) => {
        deleteAccount(req.id, (err) => {
          if (err) {
              console.log(err);
              return res.status(500).json({
                  success: 0,
                  message: "Database connection error"
              });
          }
          return res.status(200).json({
              success: 1,
              message: "account deleted successfully"
          });
      })
    },
    //tested
    getUserByEmail:(req, res) =>{
        const email = req.id;
        getUserByEmail(email, (err,results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else if(!results){
                return res.status(200).json({
                    success: 0,
                    data: "User not found"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        })
    },

//#endregion
//#region apprequests
    //not tested
    getUserByUserId: (req, res) =>{
        const id = req.body.id;
        getUserByUserId(id, (err,results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else if(!results){
                return res.status(200).json({
                    success: 0,
                    data: "User not found"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        })
    },
    //tested
    getUsers:(req, res) =>{
      getUsers((err,results) => {
          if (err) {
              console.log(err);
              return res.status(500).json({
                  success: 0,
                  message: "Database connection error"
              });
          }
          else if(!results){
              return res.status(200).json({
                  success: 0,
                  data: "User not found"
              });
          }
          return res.status(200).json({
              success: 1,
              data: results
          });
      })
  },
  getAllGames: (req, res) => {
    getGames((err, results) => {
        if (err) {
            console.log(err);
            return res.status(500).json({
                success: 0,
                message: "Database connection error"
            });
        }
        else if(!results){
            return res.status(200).json({
                success: 0,
                data: "Games not found"
            });
        }
        return res.status(200).json({
            success: 1,
            data: results
        });
    })
  },
//#endregion
//#region team
    //testing
    getTeamByUser_id: (req, res) => {
        const id = req.id;
        getTeamByUser_id(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else if(!results){
                return res.status(200).json({
                    success: 0,
                    data: "Team not found"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        });
    },
    //not tested
    //only if subscribed
    createTeam: (req, res) => {
        const name = req.body.name;
        const user_id = req.id;
        const game_id = req.body.game_id;
        const pw = Math.random().toString(36).slice(-8);
        if(name.length <= 20){
            newTeam(name, user_id, game_id, pw, (err, results) => {
                if (err) {
                    console.log(err);
                    return res.status(500).json({
                        success: 0,
                        message: "Database connection error"
                    });
                }
                else{
                    const team_id = results.insertId;
                    if(team_id != null){
                        joinTeam(team_id, user_id, (err, results) => {
                            if(err){
                                console.log(err);
                                return res.status(500).json({
                                    success: 0,
                                    message: "Database connection error"
                                });
                            }
                            else{
                                return res.status(200).json({
                                    success: 1,
                                    team_id: team_id
                                });
                            }
                        })  
                    }
                }
            }) 
        }
        else{
            return res.status(400).json({
                success: 0,
                message: "name cannot be longer than 20 characters"
            });
        }
    },
    //only if admin
    //not tested
    updateTeamName: (req, res) => {
        const user_id = req.id;
        const newname = req.body.newname;
        getTeamByUser_id(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else if(!results){
                return res.status(200).json({
                    success: 0,
                    data: "Team not found"
                });
            }
            const team_id = data.team_id
            verifyTeamAdmin(team_id, id,(req,res) => {
                if (err) {
                    console.log(err);
                    return res.status(500).json({
                        success: 0,
                        message: "Database connection error"
                    });
                }
                else if(results.count != 1){
                    return res.status(200).json({
                        success: 0,
                        data: "You are not the team admin"
                    });
                }
                updateTeamName(team_id, user_id, newname, (err, results) =>{
                    if (err) {
                        console.log(err);
                        return res.status(500).json({
                            success: 0,
                            message: "Database connection error"
                        });
                    }
                    else{
                        return res.status(200).json({
                            success: 1,
                            data: results
                        });
                    }
                });
        });
    })},
    //only if admin
    //not tested
    deleteTeam: (req, res) => {
        const id = req.id;
        getTeamByUser_id(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else if(!results){
                return res.status(200).json({
                    success: 0,
                    message: "Team not found"
                });
            }
            const team_id = results.team_id
            verifyTeamAdmin(team_id, id,(err,results) => {
                if (err) {
                    console.log(err);
                    return res.status(500).json({
                        success: 0,
                        message: "Database connection error"
                    });
                }
                else if(results.count < 1){
                    return res.status(200).json({
                        success: 0,
                        message: "You are not the team admin"
                    });
                }
                console.log(team_id);
                deleteTeam(team_id, id, (err, results) => {
                    if (err) {
                        console.log(err);
                        return res.status(500).json({
                            success: 0,
                            message: "Database connection error"
                        });
                    }
                    return res.status(200).json({
                        success: 1,
                        message: "DB OK"
                    });
                    
                })

            })
        });
    },
    joinTeam: (req, res) => {
        const id = req.id;
        const join_password = req.body.join_password;
        const team_id = req.body.team_id;
        verifyTeamJoinPassword(team_id, join_password, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            if(res.count == 1){
                joinTeam(team_id, id,(err, results) => {
                    if (err) {
                        console.log(err);
                        return res.status(500).json({
                            success: 0,
                            message: "Database connection error"
                        });
                    }
                    return res.status(200).json({
                        success: 1,
                        data: "DB OK"
                    });
                })
            }
            else{
                return res.status(200).json({
                    success: 0,
                    message: "Wrong Team ID or password"
                });
            }
            
        })
        
    },
    leaveTeam: (req, res) => {
        const id = req.id;
        leaveTeam(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            return res.status(200).json({
                success: 1,
                message: "DB OK"
            });
        });
    },
    getTeamJoinPassword: (req, res) => {
        const id = req.id;
        getTeamJoinPassword(id, (err, results) =>{
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        })
    },
    getTeamFullInfo: (req, res) => {
        const id = req.id;
        getTeamByUser_id(id, (err, results) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                const team_id = results.team_id
                getTeamFullInfo(team_id, (err, results2) => {
                    if (err) {
                        console.log(err);
                        return res.status(500).json({
                            success: 0,
                            message: "Database connection error"
                        });
                    }
                    else{
                        return res.status(200).json({
                            success: 1,
                            data: results2
                        });
                    }
                })
            }
        });
    },
    getAllTeamMembers: (req, res) => {
        const id = req.id;
        getTeamByUser_id(id, (err, results1) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            const team_id = results1.team_id;
            getTeamMembers(team_id , (err, results) => {
                if (err) {
                    console.log(err);
                    return res.status(500).json({
                        success: 0,
                        message: "Database connection error"
                    });
                }
                return res.status(200).json({
                    success: 1,
                    data: results
                });
            });
        })        
    },
//#endregion
//#region Routines
    //tested
    newRoutine: (req, res) => {
        console.log(req.id)
        const user_id = req.id;
        newRoutine(user_id, (err, results) =>{
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    message: "DB OK"
                });
            }
        })
    },
    //tested
    deleteRoutine: (req, res) => {
        const user_id = req.id;
        const routine_id = req.body.routine_id;
        deleteRoutine(user_id, routine_id, (err, results) =>{
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    message: "DB OK"
                });
            }
        })
    },
    //tested
    getRoutineContent: (req, res) => {
        const user_id = req.id;
        routine_id = req.body.routine_id;
        getRoutineContent(user_id, routine_id, (err, results) =>{
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    data:results
                });
            }
        })
    },
    //tested
    getRoutines: (req, res) => {
        const user_id = req.id;
        getRoutines(user_id, (err, results) =>{
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    data: results
                });
            }
        })
    },
    //tested
    saveRoutine: (req, res) => {
        const routine_id = req.body.routine_id;
        const user_id = req.id;
        const title = req.body.title;
        const content = req.body.content;
        saveRoutine(title, content, user_id, routine_id, (err, message) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    message: message
                });
            }
        })
    },
    //tested
    renameRoutine: (req, res) => {
        const routine_id = req.body.routine_id;
        const user_id = req.id;
        const title = req.body.title;
        renameRoutine(title, user_id, routine_id, (err, message) => {
            if (err) {
                console.log(err);
                return res.status(500).json({
                    success: 0,
                    message: "Database connection error"
                });
            }
            else{
                return res.status(200).json({
                    success: 1,
                    message: message
                });
            }
        })
    },
//#endregion
};