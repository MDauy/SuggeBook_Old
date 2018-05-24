var http = require('http'),
mongoose = require('mongoose');


var uristring = 'mongodb://localhost/suggebook';

var port = process.env.port || 5000;


mongoose.connect (uristring, function (err, res) {
    if (err)
    {
        console.log('Error connection to : ' + uristring + '. ' + err);
    }
    else
    {
        console.log ('Succeeded connected to ' + uristring);
    }
})