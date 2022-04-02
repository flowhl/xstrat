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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    clearVerification:(callBack) => {
        pool.query(
            "DELETE FROM verification WHERE time < (NOW() - INTERVAL '1' HOUR)",
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    activateAccount:(user_id, callBack) => {
        pool.query(
            "Update user SET active = 1 WHERE id = ?",
            [user_id],
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    deleteAccount: (id, callBack) =>{
        pool.query("DELETE FROM user WHERE id = ?",
        [id],
        (err,results,fields)=>{
            if(err){
               return callBack(err);
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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
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
            (err,results,fields)=>{
                if(err){
                   return callBack(err);
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
        (err,results,fields)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    getUsers: (callBack) => {
        pool.query(
            "SELECT * FROM user",
        (err,results,fields)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    getMemberByUserID: (id, callBack) => {
        pool.query(
            "SELECT * FROM team WHERE user_id = ?",
        [id],
        (err,results,fields)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    getUserByEmail: (email, callBack) =>{
        pool.query(
            "SELECT * FROM user WHERE email = ? AND active = 1",
        [email],
        (err,results,fields)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results[0]);                
        }
        );
    },
    getMyMember: (id, callBack) => {
        pool.query(
            "SELECT * FROM member WHERE user_id = ?",
        [id],
        (err,results,fields)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results[0]);                
        }
        );
    },
    getTeamByUser_id:(id, callBack) => {
        pool.query(
            "SELECT team_id FROM user WHERE id = ?",
        [id],
        (err,results,fields)=>{
            if(err){
            return callBack(err);
            }
            return callBack(null,results[0]);
        }
        );
    },
    newTeam: (name, user_id, game_id, pw, callBack) => {     
        console.log(name, user_id, game_id, pw);
        pool.query("INSERT INTO team (name, admin_user_id, game_id, join_password) Values (?,?,?,?)",
        [
            name,
            user_id,
            game_id, 
            pw
        ],
        (err,results,fields) => {
            if(err){
                console.log(err);
                return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    updateTeamName: (team_id, user_id, newname, callBack) =>{
        pool.query(
            'Update team SET name = ? WHERE id = ? AND admin_user_id = ?',
            [
                newname,
                team_id,
                user_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    deleteTeam: (team_id, user_id, callBack) => {
        pool.query(
            'DELETE FROM team WHERE id = ? AND admin_user_id = ?',
            [
                team_id,
                user_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );

    },
    verifyTeamJoinPassword: (team_id, join_password) =>{
        pool.query(
            'SELECT COUNT(id) AS count FROM team WHERE id = ? AND join_password = ?',
            [
                team_id,
                join_password
            ],
            (err,results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(results,"DB OK");                
            }
        );
    },
    verifyTeamAdmin: (team_id, user_id, callBack) => {
        pool.query(
            'SELECT COUNT(id) FROM team WHERE id = ? AND admin_user_id = ?',
            [
                team_id,
                user_id
            ],
            (err,results)=>{
                if(err){
                   return callBack(err);
                }
                
                return callBack(null,results);                
            }
        );
    },
    joinTeam: (team_id, user_id, callBack) => {
        pool.query(
            'Update user SET team_id = ? WHERE id = ?',
            [
                team_id,
                user_id
            ],
            (err,results,fields) => {
                if(err){
                    console.log(err);
                    return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    leaveTeam: (user_id, callBack) => {
        pool.query(
            'Update user SET team_id = null WHERE id = ?',
            [
                user_id
            ],
            (err)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    getTeamJoinPassword: (user_id, callBack) => {
        pool.query(
            'SELECT id, join_password FROM team WHERE admin_user_id = ?',
            [
                user_id
            ],
            (err, result)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, result);                
            }
        );
    },
    getTeamInfo: (user_id, callBack) => {
        pool.query(
            'SELECT id, join_password FROM team WHERE admin_user_id = ?',
            [
                user_id
            ],
            (err, result)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, result);                
            }
        );
    },

//#endregion
//#region routines
    newRoutine: (user_id, callBack) => {
        pool.query( 'INSERT INTO routine (title, user_id) VALUES(?,?)',
        [
            "Routine",
            user_id
        ],
        (err,results,fields) => {
            if(err){
                console.log(err);
                return callBack(err);
            }
            console.log(results);
            return callBack(null,results);                
        }
        )
    },
    deleteRoutine: (user_id, routine_id, callBack) =>{
        pool.query( 'DELETE FROM routine WHERE user_id = ? AND id = ?',
        [
            user_id,
            routine_id
        ],
        (err,results,fields) => {
            if(err){
                console.log(err);
                return callBack(err);
            }
            console.log(results);
            return callBack(null,results);                
        }
        )
    },
    getRoutineContent: (user_id, routine_id, callBack) => {
        pool.query(
            'SELECT content FROM routine WHERE id = ? AND user_id = ?',
            [
                routine_id,
                user_id
            ],
            (err,results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    getRoutines: (user_id, callBack) => {
        pool.query(
            'SELECT * FROM routine WHERE user_id = ?',
            [
                user_id
            ],
            (err,results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        );
    },
    saveRoutine: (title, content, user_id, routine_id, callBack) => {
        pool.query(
            'Update routine SET title = ?, content = ? WHERE user_id = ? AND id = ?',
            [
                title,
                content,
                user_id,
                routine_id
            ],
            (err)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );
    },
    renameRoutine: (title, user_id, routine_id, callBack) => {
        pool.query(
            'Update routine SET title = ? WHERE user_id = ? AND id = ?',
            [
                title,
                user_id,
                routine_id
            ],
            (err)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );
    },





//#endregion
};
