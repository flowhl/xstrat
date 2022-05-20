const jwt = require("jsonwebtoken");
const { create_log, getTeamByUser_id, verifyTeamAdmin } = require("../api/users/user.service");
module.exports = {
  checkToken: (req, res, next) => {
    let token = req.headers["authorization"];
    if (token) {      
      token = token.split(" ")[1];// Remove Bearer from string
      jwt.verify(token, process.env.KEY, (err, decoded) => {
        if (err) {
          return res.status(401).json({
            success: 0,
            message: "Invalid Token..."
          });
        } else {
          req.decoded = decoded;
          req.email = decoded.email;
          req.id = decoded.id;
          //logging
          create_log(req.originalUrl)
          next();
        }
      });
    } else {
      return res.status(401).json({
        success: 0,
        message: "Access Denied! Unauthorized User"
      });
    }
  },
  checkAdmin: (req, res, next) => {
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
            verifyTeamAdmin(team_id, id,(err2,results2) => {
                if (err) {
                    console.log(err2);
                    return res.status(500).json({
                        success: 0,
                        message: "Database connection error"
                    });
                }
                else if(results2[0].count != 1){
                    return res.status(200).json({
                        success: 0,
                        message: "You are not the team admin"
                    });
                }
                next();
        });
    })},

};