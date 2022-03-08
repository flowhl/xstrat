const res = require("express/lib/response");
const pool = require("../../config/database");

module.exports = {
//#region user control
    create_user:(data, callBack) =>{
        pool.query(
            "INSERT INTO user (name, email, password) values(?,?,?)",
            [
                data.name,
                data.email,
                data.password,
            ],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                console.log(results);
                return callBack(null,results);                
            }
        );
    },
    createVerification:(token, user_id, callBack) =>{
        pool.query(
            "INSERT INTO verification (string, user_id) values(?,?)",
            [
                token,
                user_id
            ],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                console.log(results);
                return callBack(null,results);                
            }
        );
    },
    getVerification:(token, callBack) => {
        pool.query(
            "SELECT * FROM verification WHERE string = ? AND time > (NOW() - INTERVAL '1' HOUR)",
            [token],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,results);                
            }
        );
    },
    clearVerification:(callBack) => {
        pool.query(
            "DELETE FROM verification WHERE time < (NOW() - INTERVAL '1' HOUR)",
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,results);                
            }
        );
    },
    activateAccount:(user_id, callBack) => {
        pool.query(
            "Update user SET active = 1 WHERE id = ?",
            [user_id],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,results);                
            }
        );
    },
    deleteAccount: (id, callBack) =>{
        pool.query("DELETE FROM user WHERE id = ?",
        [id],
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
                return callBack(null,results);
        }
        );
    },
    changeEmail: (data, id, callBack) => {
        pool.query(
            'Update user SET email = ? WHERE id = ?',
            [
                data.email,
                id
            ],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    changeName: (data, id, callBack) => {
        pool.query(
            'Update user SET email = ? WHERE id = ?',
            [
                data.name,
                id
            ],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    changePassword: (data, id, callBack) => {
        pool.query(
            'Update user SET email = ? WHERE id = ?',
            [
                data.password,
                id
            ],
            (error,results,fields)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    
    },
//#endregion
//#region apprequests
    getUserByUserId: (id, callBack) =>{
        pool.query(
            "SELECT * FROM user WHERE id = ?",
        [id],
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
            return callBack(null,results);                
        }
        );
    },
    getUsers: (callBack) => {
        pool.query(
            "SELECT * FROM user",
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
            return callBack(null,results);                
        }
        );
    },
    getMemberByUserID: (id, callBack) => {
        pool.query(
            "SELECT * FROM team WHERE user_id = ?",
        [id],
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
            return callBack(null,results);                
        }
        );
    },
    getUserByEmail: (email, callBack) =>{
        pool.query(
            "SELECT * FROM user WHERE email = ? AND active = 1",
        [email],
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
            return callBack(null,results[0]);                
        }
        );
    },
    getMyMember: (id, callBack) => {
        pool.query(
            "SELECT * FROM member WHERE user_id = ?",
        [id],
        (error,results,fields)=>{
            if(error){
               return callBack(error);
            }
            return callBack(null,results[0]);                
        }
        );
    },
    getTeamByUser_id:(id, callBack) => {
        pool.query(
            "SELECT team_id FROM user WHERE id = ?",
        [id],
        (error,results,fields)=>{
            if(error){
            return callBack(error);
            }
            return callBack(null,results[0]);
        }
        );
    },
    newTeam: (name, user_id, game_id, pw, callBack) => {
        //for some reason this sql does not work - fix later
        pool.query("INSERT INTO team (name, admin_user_id, game_id, join_password) values(?,?,?,?)"),
        [name, user_id, game_id, pw],
        (error,results,fields) => {
            if(error){
                console.log(err);
                return callBack(error);
            }
            console.log(results);
            return callBack(null,results);                
        };
    },
    updateTeamName: (team_id, user_id, newname) =>{
        pool.query(
            'Update team SET name = ? WHERE id = ? AND admin_user_id = ?',
            [
                newname,
                team_id,
                user_id
            ],
            (error, results)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    deleteTeam: (team_id, user_id,) => {
        pool.query(
            'DELETE FROM team WHERE id = ? AND admin_user_id = ?',
            [
                team_id,
                user_id
            ],
            (error, results)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );

    },
    verifyTeamJoinPassword: (team_id, join_password) =>{
        pool.query(
            'SELECT COUNT(id) FROM team WHERE id = ? AND join_password = ?',
            [
                team_id,
                join_password
            ],
            (error,results)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(results,"DB OK");                
            }
        );
    },
    verifyTeamAdmin: (team_id, user_id) =>{
        pool.query(
            'SELECT COUNT(id) FROM team WHERE id = ? AND admin_user_id = ?',
            [
                team_id,
                user_id
            ],
            (error,results)=>{
                if(error){
                   return callBack(error);
                }
                
                return callBack(null,results);                
            }
        );
    },
    joinTeam: (team_id, user_id) => {
        pool.query(
            'Update user SET team_id = ? WHERE id = ?',
            [
                team_id,
                user_id
            ],
            (error)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    leaveTeam: (user_id) => {
        pool.query(
            'Update user SET team_id = null WHERE id = ?',
            [
                user_id
            ],
            (error)=>{
                if(error){
                   return callBack(error);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    

//#endregion
//#region routines
    // newRoutine: (name, team_id, callBack) {
        
    // }


//#endregion
};
