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
     verifyToken,
     getTeamByUser_id,
     deleteUser,
     createTeam,
     activateAccount,
     newRoutine,
     deleteRoutine,
     getRoutineContent,
     getRoutines,
     saveRoutine,
     testConnection,
     renameRoutine,
     getTeamJoinPassword,
     deleteTeam,
     leaveTeam,
     updateTeamName,
     joinTeam,
     getAllTeamMembers,
     getTeamFullInfo,
     getAllGames,
     checkTeamAdmin
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
router.post("/teamofuser",[checkToken], getTeamByUser_id)
//#endregion
//#region apprequests
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
router.get("/", testConnection);
router.get("/getusers", [checkToken], getUsers)
router.get("/account/activate/:token", activateAccount)
router.get("/games", [checkToken], getAllGames)
//#endregion
//#region Routines
router.post("/routines/new", [checkToken], newRoutine)
router.post("/routines/delete", [checkToken], deleteRoutine)
router.post("/routines/content", [checkToken], getRoutineContent)
router.get("/routines/all", [checkToken], getRoutines)
router.post("/routines/save", [checkToken], saveRoutine)
router.post("/routines/rename", [checkToken], renameRoutine)
//#endregion
//#region team
// router.get("/team/info", [checkToken],) //missing stuff
router.get("/team/joinpassword", [checkToken], getTeamJoinPassword)
router.get("/team/leave", [checkToken], leaveTeam)
router.get("/team/members", [checkToken], getAllTeamMembers)
router.get("/team/info", [checkToken], getTeamFullInfo)
router.get("/team/verifyadmin", [checkToken], checkTeamAdmin)

router.post("/team/delete", [checkToken], deleteTeam)
router.post("/team/new", [checkToken], createTeam)
router.post("/team/rename", [checkToken], updateTeamName)
router.post("/team/join", [checkToken], joinTeam)

//#endregion
module.exports = router