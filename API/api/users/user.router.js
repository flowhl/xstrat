const {
     createUser,
     getUserByUserId, 
     getUserByEmail, 
     login, 
     getUsers, 
     deleteAccount, 
     changeEmail, 
     changeName, 
     changePassword,
     getMyMember,
     verifyToken,
     getTeamByUser_id,
     deleteUser,
     createTeam
    } = require("./user.controller");
const router = require("express").Router();
const {checkToken} = require("../../auth/token_validation");

//#region user control
router.post("/login", login)
router.post("/register",createUser)
router.post("/verify",[checkToken],verifyToken)
router.post("/changeEmail", [checkToken], changeEmail)
router.post("/changeName", [checkToken], changeName)
router.post("/changePassword", [checkToken], changePassword)
router.post("/deleteAccount", [checkToken], deleteAccount)
//#endregion
//#region apprequests
router.get("/mymember", [checkToken], getMyMember)
// router.get("/mygame", [checkToken], getMyGame) //game of my team
// router.get("/myteam", [checkToken], getMyTeam) 
// router.get("/gamebyteamid", [checkToken], getGameByTeamId)
// router.get("/maps", [checkToken], getMaps)
// router.get("/mappositions", [checkToken], getMapPositions)
// router.get("/stratsbyposition", [checkToken], getStratsByPosition) // get strat id by position and team
// router.get("/stratbyid", [checkToken], getStratById)
// router.get("/playerstrat",checkToken, getPlayerStrat)

//#region team management
// router.post("/joinTeam", [checkToken], joinTeam)
// router.post("/teamJoinGame", [checkToken], teamJoinGame)
// router.post("/setTeamAdmin", [checkToken], setTeamAdmin)
// router.post("/newStrat", [checkToken], newStrat)

router.get("/myteamid", [checkToken], getTeamByUser_id)
router.post("/createteam", [checkToken], createTeam)
router.get("/", getUserByUserId);
router.get("/getusers", [checkToken], getUsers)
//#endregion
module.exports = router