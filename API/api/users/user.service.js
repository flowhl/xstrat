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
    create_member:(user_id, callBack) =>{
        pool.query(
            "INSERT INTO member (user_id) values(?)",
            [
                user_id
            ],
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
            "SELECT * FROM user WHERE email = ?",
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
    }
//#endregion
};
