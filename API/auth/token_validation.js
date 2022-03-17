const jwt = require("jsonwebtoken");
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
          console.log("decoded",decoded);
          req.email = decoded.email;
          req.id = decoded.id;
          console.log("req", req.id)
          next();
        }
      });
    } else {
      return res.status(401).json({
        success: 0,
        message: "Access Denied! Unauthorized User"
      });
    }
  }
};