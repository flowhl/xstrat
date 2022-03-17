const { create_user, getMemberByUserID,getUserByUserId,getUsers,getUserByEmail, deleteAccount, changeEmail, changeName, changePassword, getMyMember, getTeamByUser_id, updateTeamName, deleteTeam, newTeam, createVerification, getVerification, clearVerification, activateAccount, newRoutine, deleteRoutine, getRoutineContent, saveRoutine, getRoutines, renameRoutine} = require("./user.service");

const {genSaltSync, hashSync, compareSync} = require("bcrypt");
const { sign } = require("jsonwebtoken");
const {sendEmail} = require("./user.mailservice");
const res = require("express/lib/response");
module.exports = {
//#region user control
    testConnection: (req, res) => {
        return res.status(200).json({
            success: 1
            });
    },

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
    verifyToken:(req, res) =>{
        return res.status(200).json({
            success: 1
        });
    },
    changeEmail: (req, res) => {
        const body = req.body;
          const id = req.params.id;
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
    changeName: (req, res) => {
      const body = req.body;
        const id = req.params.id;
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
    changePassword: (req, res) => {
    const id = req.params.id;
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
    getUserByEmail:(req, res) =>{
        const email = req.params.id;
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
    getMyMember: (req, res) => {
        const id = req.id;
        getMyMember(id, (err, results) => {
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
                    data: "Member not found"
                });
            }
            return res.status(200).json({
                success: 1,
                data: results
            });
        })
    },

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
//#endregion
//#region team
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
    createTeam: (req, res) => {
        const name = req.body.name;
        const user_id = req.id;
        const game_id = req.body.game_id;
        const pw = Math.random().toString(36).slice(-8);
        newTeam(name, user_id, game_id, pw, (err, results) => {
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
    //only if admin
    updateTeamName: (req, res) => {
        const team_id = req.params.team_id;
        const user_id = req.id;
        const newname = req.params.newname;
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
        })
    },
    //only if admin
    deleteTeam: (req, res) => {
        //ENTER HERE
    },
//#endregion
//#region Routines
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