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
     checkTeamAdmin,
     getMyColor,
     setMyColor,
     newEvent,
     deleteEvent,
     getTeamEvents,
     getUserEvents,
     saveEvent,
     newScrim,
     deleteScrim,
     getTeamScrims,
     saveScrim,
     getMaps,
     setMyDiscord,
     getMyDiscord,
     getDiscordData,
     setDiscordData,
     getScrimResponse,
     setScrimResponse,
     getUbisoftId,
     setUbisoftId,
     testRun
    } = require("./user.controller");
const router = require("express").Router();
const {checkToken, checkAdmin} = require("../../auth/token_validation");


const R6 = require('../../tracker/r6stats');
let email = '';
let password = '';
let platform = 'uplay';

let account = R6.createAccount(email, password, platform);



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
router.get("/maps", [checkToken], getMaps)
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
router.get("/team/joinpassword", [checkToken], getTeamJoinPassword)
router.get("/team/leave", [checkToken], leaveTeam)
router.get("/team/members", [checkToken], getAllTeamMembers)
router.get("/team/info", [checkToken], getTeamFullInfo)
router.get("/team/verifyadmin", [checkToken, checkAdmin], checkTeamAdmin)
router.get("/team/getcolor", [checkToken], getMyColor)
router.get("/team/getdiscord", [checkToken], getMyDiscord)
router.get("/team/getdiscordata",[checkToken, checkAdmin], getDiscordData)


router.post("/team/delete", [checkToken, checkAdmin], deleteTeam)
router.post("/team/new", [checkToken], createTeam)
router.post("/team/rename", [checkToken, checkAdmin], updateTeamName)
router.post("/team/join", [checkToken], joinTeam)
router.post("/team/setcolor", [checkToken], setMyColor)
router.post("/team/setdiscord", [checkToken], setMyDiscord)
router.post("/team/setdiscorddata",[checkToken, checkAdmin], setDiscordData)

//#endregion

//#region offdays
router.post("/event/new",[checkToken], newEvent)
router.post("/event/delete",[checkToken], deleteEvent)
router.get("/event/team",[checkToken], getTeamEvents)
router.get("/event/user",[checkToken], getUserEvents)
router.post("/event/save",[checkToken], saveEvent)

//#endregion

//#region scrims

router.post("/scrim/new",[checkToken], newScrim)
router.post("/scrim/delete",[checkToken, checkAdmin], deleteScrim)
router.get("/scrim/team",[checkToken], getTeamScrims)
router.get("/scrim/getresponse",[checkToken], getScrimResponse)
router.post("/scrim/save",[checkToken], saveScrim)
router.post("/scrim/setresponse",[checkToken], setScrimResponse)

//#region tracker

router.get("/user/getubisoftid",[checkToken], getUbisoftId)
router.post("/user/setubisoftid",[checkToken], setUbisoftId)
router.get("/tracker/stats",async function(req, res){

    const username = req.body.username;
    const region = req.body.region;

    let session = await R6.createSession(account).catch(e => { console.error(e) }); 
    let player = await R6.createPlayer(username, platform, session).catch(e => { console.error(e) }); 

    let stats = await R6.getStats(player, session, region).catch(e => { console.error(e) });
    if(stats != undefined){
        return res.status(200).json({
            success: 1,
            data: stats
        });
    }
    else{
        return res.status(500).json({
            success: 0
        });
    }
  })

  router.get("/tracker/statsbyseason",async function(req, res){

    const username = req.body.username;
    const region = req.body.region;
    const season = req.body.season;

    let session = await R6.createSession(account).catch(e => { console.error(e) }); 
    let player = await R6.createPlayer(username, platform, session).catch(e => { console.error(e) }); 

    let stats = await R6.getStatsBySeason(player, session, season, region).catch(e => { console.error(e) });
    if(stats != undefined){
        return res.status(200).json({
            success: 1,
            data: stats
        });
    }
    else{
        return res.status(500).json({
            success: 0
        });
    }
  })

  router.get("/tracker/statsbyoperator",async function(req, res){

    const username = req.body.username;
    const team = req.body.team;

    let session = await R6.createSession(account).catch(e => { console.error(e) }); 
    let player = await R6.createPlayer(username, platform, session).catch(e => { console.error(e) }); 

    let stats = await R6.getStatsByOperator(player, session, team).catch(e => { console.error(e) });
    if(stats != undefined){
        return res.status(200).json({
            success: 1,
            data: stats
        });
    }
    else{
        return res.status(500).json({
            success: 0
        });
    }
  })
//#endregion
module.exports = router