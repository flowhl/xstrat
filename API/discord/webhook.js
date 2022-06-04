const { Webhook, MessageBuilder } = require('discord-webhook-node');
const { getUserByUserId, getScrimReminders, getScrimParticipants, setScrimSent, getTeamsWithSummaryEnabled, getTeamScrimInWeek } = require('../api/users/user.service');
const blue = "#2D9ED5";
const red = "#D64251";
const orange = "#E3673B";
const yellow = "#E3DE52";
const green = "#4AB859";

//cron
const cron = require('node-cron');

// Schedule tasks to be run on the server.
cron.schedule('*/5 * * * *', function() {
    console.log("Scrim reminder check started");
    module.exports.ScrimReminder();
});
cron.schedule('0 1 * * MON', function() {
    console.log("Weekly summary check started");
    module.exports.QueueWeeklySummary();
});

module.exports = {
  ScrimCreatedNotification: (webhook_url, creator_id, title, opponent_name) => 
  {        
    if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
    {
        getUserByUserId(creator_id, (err, results) => 
        {
            const user_name = results[0].name;
            const hook = new Webhook(
            {
                url: webhook_url,
                //If throwErrors is set to false, no errors will be thrown if there is an error sending
                throwErrors: true,
                //retryOnLimit gives you the option to not attempt to send the message again if rate limited
                retryOnLimit: true
            });

            const embed = new MessageBuilder()
            .setTitle('Scrim created against ' + opponent_name) 
            .setColor(green)
            .setDescription('Created by ' + user_name)
            .setFooter('You can find more details on the XStrat app')
            .setTimestamp();

            hook.send(embed)
            .then(() => console.log('Sent created webhook successfully:', title))
            .catch(err => console.log(err.message));
        })

    } 
    else{
        console.log("wrong webhook url:", webhook_url);
    } 
        
},
ScrimChangedNotification: (webhook_url, time_start ,time_end, title, opponent_name, user_id) => 
  {        
    if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
    {
        getUserByUserId(user_id, (err, results) => 
        {
            if(err){
                console.log(err);
            }
            const user_name = results[0].name;
            const hook = new Webhook(
            {
                url: webhook_url,
                //If throwErrors is set to false, no errors will be thrown if there is an error sending
                throwErrors: true,
                //retryOnLimit gives you the option to not attempt to send the message again if rate limited
                retryOnLimit: true
            });

            const embed = new MessageBuilder()
            .setTitle('Scrim time against ' + opponent_name + ' was changed')
            .setColor(orange)
            .setDescription( 'New time: ' + time_start.split(" ")[1].replace(":00","") + '-' + time_end.split(" ")[1].replace(":00","") + '\n Changed by ' + user_name)
            .setFooter('You can find more details on the XStrat app')
            .setTimestamp();

            hook.send(embed)
            .then(() => console.log('Sent changed webhook successfully:', title))
            .catch(err => console.log(err.message));
        })

    } 
    else{
        console.log("wrong webhook url:", webhook_url);
    } 
        
},
ScrimDeletedNotification: (webhook_url, user_id , title, opponent_name, time_start, time_end) => 
  {        
    if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
    {
        getUserByUserId(user_id, (err, results) => 
        {            
            if(err){
                console.log(err);
            }

            const user_name = results[0].name;
            const hook = new Webhook(
            {
                url: webhook_url,
                //If throwErrors is set to false, no errors will be thrown if there is an error sending
                throwErrors: true,
                //retryOnLimit gives you the option to not attempt to send the message again if rate limited
                retryOnLimit: true
            });

            const embed = new MessageBuilder()
            .setTitle('Scrim against ' + opponent_name + ' was deleted')
            .setColor(red)
            .setDescription('Title: ' + title + '\nTime: ' + time_start.split(" ")[1].replace(":00","") + '-' + time_end.split(" ")[1].replace(":00","") + "\nDeleted by: " + user_name)
            .setFooter('You can find more details on the XStrat app')
            .setTimestamp();

            hook.send(embed)
            .then(() => console.log('Sent deleted webhook successfully:', title))
            .catch(err => console.log(err.message));
        })

    } 
    else{
        console.log("wrong webhook url:", webhook_url);
    } 
        
},
ScrimStaringSoonNotification: (webhook_url, scrim_id, title, opponent_name, time_start, time_end, sn_delay, time_diff) => 
  {        
    if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
    {
        console.log(webhook_url, scrim_id, title, opponent_name, time_start, time_end, sn_delay)
        getScrimParticipants(scrim_id, (err, results) => {
            var pstring = "";
            if(err){
                console.log(err)
            }
            else if(results != null){
                results.forEach(element => {
                    pstring = pstring + element.name;
                    if(element.discord != null && element.discord != undefined && element.discord != ""){
                        pstring = pstring + " <@" + element.discord + ">";
                    }
                    pstring = pstring + " "
                })
            }
            const hook = new Webhook(
            {
                url: webhook_url,
                //If throwErrors is set to false, no errors will be thrown if there is an error sending
                throwErrors: true,
                //retryOnLimit gives you the option to not attempt to send the message again if rate limited
                retryOnLimit: true
            });

            const embed = new MessageBuilder()
            .setTitle('Scrim against ' + opponent_name + ' starting in about ' + time_diff + ' minutes')
            .setColor(blue)
            .setDescription('Title: ' + title + '\nTime: ' + time_start.split(" ")[1].replace(":00","") + '-' + time_end.split(" ")[1].replace(":00","") + '\n Player: ' + pstring)
            .setFooter('You can find more details on the XStrat app')
            .setTimestamp();

            hook.send(embed)
            .then(() => {
                console.log('Sent starting soon webhook successfully:', title);
                setScrimSent(scrim_id, (err, results) =>{
                    if(err){
                        console.log(err)
                    }
                })
            }  )
            .catch(err => console.log(err.message));
        })

    } 
    else{
        console.log("wrong webhook url:", webhook_url);
    } 
        
},
ScrimReminder() 
  {        
    getScrimReminders((err, results) => {
        if(err) {
            console.log(err);
        }
        else{
            results.forEach(element => {
                console.log(element.webhook, element.scrim_id, element.title, element.opponent_name, element.time_start, element.time_end, element.sn_delay, element.time_diff)
                module.exports.ScrimStaringSoonNotification(element.webhook, element.scrim_id, element.title, element.opponent_name, element.time_start, element.time_end, element.sn_delay, element.time_diff);
            });
        }
    })
  },

  WeeklySummaryForTeam:(team_id, webhook_url) => {
    getTeamScrimInWeek(team_id, (err, results) => {
        if(err){
            console.log(err)
        }
        else{
            if(results.length > 0 ){
                if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
                {
                    var liststring = "";

                    results.forEach(
                        element =>{
                            let substring = "";
                            if(results.indexOf(element) != 0 ){
                                substring += '\n---------------------------------\n\n'
                            }                            

                            substring += '** Scrim on: ' + element.time_start.split(" ")[0] + '**';
                            substring += '\n**Time:** ' + element.time_start.split(" ")[1].replace(":00","") + '-' + element.time_end.split(" ")[1].replace(":00","");
                            substring += '\n**Title:** ' + element.title;
                            substring += '\n**Against:** ' + element.opponent_name ;
                            
                            liststring += "\n" + substring
                        }
                            
                    )


                    const hook = new Webhook(
                        {
                            url: webhook_url,
                            //If throwErrors is set to false, no errors will be thrown if there is an error sending
                            throwErrors: true,
                            //retryOnLimit gives you the option to not attempt to send the message again if rate limited
                            retryOnLimit: true
                        });
            
                        const embed = new MessageBuilder()
                        .setTitle('Scrim summary for this week:')
                        .setColor(blue)
                        .setDescription(liststring)
                        .setFooter('You can find more details on the XStrat app')
                        .setTimestamp();
            
                        hook.send(embed)
                        .then(() => console.log('Sent header webhook successfully for team: ' + team_id))
                        .catch(err => console.log(err.message));

                }
            }
            
        }
    })
  },

//   WeeklySummarySendWebhook(webhook_url, time_start ,time_end, title, opponent_name, user_id){
//     if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
//     {
//         getUserByUserId(user_id, (err, results) => 
//         {
//             if(err){
//                 console.log(err);
//             }
//             const user_name = results[0].name;
//             const hook = new Webhook(
//             {
//                 url: webhook_url,
//                 //If throwErrors is set to false, no errors will be thrown if there is an error sending
//                 throwErrors: true,
//                 //retryOnLimit gives you the option to not attempt to send the message again if rate limited
//                 retryOnLimit: true
//             });

//             const embed = new MessageBuilder()
//             .setTitle('Scrim against ' + opponent_name)
//             .setColor(green)
//             .setDescription('Title: ' + title + '\nTime: ' + time_start.replace(":00","") + '-' + time_end.split(" ")[1].replace(":00","") + "\nCreated by: " + user_name)

//             hook.send(embed)
//             .then(() => console.log('Sent deleted webhook successfully:', title))
//             .catch(err => console.log(err.message));
//         })

//     } 
//     else{
//         console.log("wrong webhook url:", webhook_url);
//     } 
//   },

  QueueWeeklySummary() {
    getTeamsWithSummaryEnabled((err, results) => {
        if(err){
            console.log(err)
        }
        else{
            results.forEach(element =>  module.exports.WeeklySummaryForTeam(element.team_id, element.webhook))
        }
    })
},

  

};