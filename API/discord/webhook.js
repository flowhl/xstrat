const { Webhook, MessageBuilder } = require('discord-webhook-node');
const { getUserByUserId } = require('../api/users/user.service');
module.exports = {
  ScrimCreatedNotification: (webhook_url, creator_id, title, opponent_name) => 
  {        
    if( String(webhook_url).startsWith("https://discord.com/api/webhooks/"))
    {
        getUserByUserId(creator_id, (err, results) => 
        {
            const user_name = results.name;
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
            .setColor('#336cb5')
            .setDescription('Created by ' + user_name)
            .setFooter('You can find more details on the XStrat app')
            .setTimestamp();

            hook.send(embed)
            .then(() => console.log('Sent webhook successfully:', title))
            .catch(err => console.log(err.message));
        })

    } 
    else{
        console.log("wrong webhook url:", webhook_url);
    } 
        
},

};