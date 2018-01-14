'use strict';
var mongoose = require('mongoose');
var authorModel = require('./authorModel');
var Schema = mongoose.Schema;

var BookSchema = new Schema({
    name: {
        type: String,
        required: 'Entrez le nom du livre'
    },
    created_date: {
        type: Date,
        default: Date.now
    },
    author: {
        type: authorModel
    }
})