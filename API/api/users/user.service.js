const res = require("express/lib/response");
const { getEventListeners } = require("nodemailer/lib/ses-transport");
const { callbackPromise } = require("nodemailer/lib/shared");
const { end } = require("../../config/database");
const pool = require("../../config/database");

module.exports = {
//#region logging
    create_log: (requestUri) =>{
        pool.query(
            "INSERT INTO logs(request) VALUES (?)",
            [requestUri],
            (err,results)=>{
            if(err){
              console.log("logging error:",err)
            }
                
            }
        );
    },
//#endregion
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
    getGames: (callBack) => {
        pool.query(
            "SELECT * FROM game",
        (err,results)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    getMaps: (team_id, callBack) => {
        pool.query(
            "SELECT map.* FROM map join team on team.game_id = map.game_id WHERE team.id = ?",[
                team_id
            ],
        (err,results)=>{
            if(err){
               return callBack(err);
            }
            return callBack(null,results);                
        }
        );
    },
    getMemberByUserID: (id, callBack) => {
        pool.query(
            "SELECT * FROM team WHERE user_id = ? AND deleted = 0",
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
            'UPDATE team SET deleted = 1 WHERE id = ? AND admin_user_id = ?',
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
    verifyTeamJoinPassword: (team_id, join_password, callBack) =>{
        console.log(team_id, join_password)
        pool.query(
            'SELECT COUNT(id) AS count FROM team WHERE id = ? AND join_password = ? AND deleted = 0',
            [
                team_id,
                join_password
            ],
            (err,results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    verifyTeamAdmin: (team_id, user_id, callBack) => {
        pool.query(
            'SELECT COUNT(id) count FROM team WHERE id = ? AND admin_user_id = ? AND deleted = 0',
            [
                team_id,
                user_id
            ],
            (err,results, fields)=>{
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
            'SELECT id, join_password FROM team WHERE admin_user_id = ? AND deleted = 0',
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
    getTeamFullInfo: (team_id, callBack) => {
        pool.query(
            'SELECT team.name team_name, user.name admin_name, game.name game_name FROM team JOIN user ON user.id = team.admin_user_id LEFT JOIN game ON game.id = team.game_id WHERE team.id = ? AND team.deleted = 0',
            [
                team_id
            ],
            (err, result)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, result);                
            }
        );
    },
    getTeamMembers: (team_id, callBack) => {
        pool.query(
            "SELECT id, name, color FROM user WHERE user.team_id = ?",
            [
                team_id
            ],
            (err, results, fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    getMyColor: (user_id, callBack) => {
        pool.query(
            "SELECT color FROM user WHERE user.id = ?",
            [
                user_id
            ],
            (err, results, fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    setMyColor: (user_id, color, callBack) => {
        pool.query(
            "Update user Set color = ? WHERE user.id = ?",
            [
                color,
                user_id
            ],
            (err, results, fields)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, "DB OK");                
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
//#region events

    createEvent: (user_id, typ, title, start, end, callBack) => {
        pool.query(
            'INSERT INTO offday (user_id, typ, title, start, end) VALUES (?,?,?,?,?)',
            [
                user_id,
                typ,
                title,
                start,
                end
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    deleteEvent: (user_id, event_id, callBack) => {
        pool.query(
            'DELETE FROM offday WHERE user_id = ? AND id = ?',
            [
                user_id,
                event_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    getTeamEvents:(team_id, callBack) => {
        pool.query(
            'SELECT offday.* FROM offday JOIN user ON offday.user_id = user.id WHERE user.team_id = ?',
            [
                team_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        )
    },
    getUserEvents:(user_id, callBack) => {

        pool.query(
            'SELECT * FROM offday WHERE user_id = ?',
            [
                user_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        )
    },
    saveEvent:(id, user_id, typ, title, start, end, callBack) => {
        pool.query(
            'Update offday SET typ = ?, title = ?, start = ?, end = ? WHERE id = ? AND user_id = ?',
            [
                typ,
                title,
                start,
                end,
                id,
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

    //#endregion
    //#region scrims

    createScrim: (user_id, title, time_start, time_end, team_id, typ, callBack) => {
        pool.query(
            'INSERT INTO scrim (title, time_start, time_end, team_id, typ, creator_id) VALUES (?,?,?,?,?,?)',
            [
                title,
                time_start,
                time_end,
                team_id,
                typ,
                user_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    deleteScrim: (user_id, scrim_id, callBack) => {
        pool.query(
            'DELETE FROM scrim WHERE creator_id = ? AND id = ?',
            [
                user_id,
                scrim_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null, results);                
            }
        );
    },
    getTeamScrim:(team_id, callBack) => {
        pool.query(
            'SELECT * FROM scrim WHERE team_id = ?',
            [
                team_id
            ],
            (err, results)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,results);                
            }
        )
    },
    saveScrim:(id, title, comment, time_start, time_end, opponent_name, team_id, map_1_id, map_2_id, map_3_id, typ, callBack) => {
        console.log(id, title, comment, time_start, time_end, opponent_name, team_id, map_1_id, map_2_id, map_3_id, typ)
        pool.query(
            'Update scrim SET title = ? , comment = ? , time_start = ? , time_end = ? , opponent_name = ? ,  map_1_id = ? , map_2_id = ? , map_3_id = ? , typ = ? WHERE id = ? AND team_id = ?'
            [
                title,
                comment,
                time_start,
                time_end,
                opponent_name,
                map_1_id,
                map_2_id,
                map_3_id,
                typ,
                id,
                team_id
            ],
            (err)=>{
                if(err){
                   return callBack(err);
                }
                return callBack(null,"DB OK");                
            }
        );
    }

    //#endregion
};
