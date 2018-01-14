var mongoose = require('mongoose'),
 Schema = mongoose.Schema,
 autoIncrement = require('mongoose-auto-increment');


var AuthorSchema = new Schema ({
    _id:{
        type:Number
    },
    lasname:{
        type:String
    },
    firstname:{
        type:String
    },
    nationality:{
        type:String
    }
})


module.exports = mongoose.model("Authors", AuthorSchema);