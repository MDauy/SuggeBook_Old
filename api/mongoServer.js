var MongoClient = require('mongodb').MongoClient,
    commandLineArgs = require('command-line-args'),
    asser = require('assert');

var options = commandLineOptions();

MongoClient.connect('mongodb://localhost:27017/mabase', function (err, db) {
    assert.equal(err, null);
    console.log("Successfully connected to MongoDb");

    query = queryDocument(options)//mongo db query;
    var projection = { "name": 1, "blabla": 1, "_id": 0 }
    var cursor = db.collection('macollection').find(query, projection);

    cursor.forEach(function (doc) {
        //traitement
    })
})

function commandLineOptions() {
    var cli = commandLineArgs([
        { name: "paramA", alias: "a", type: Number },
        { name: "paramB", alias: "b", type: string }]);

    var options = cli.parse();
    if (!(("paramA" in options) && ("paramB" in options))) {
        console.log(cli.getUsage({
            title: "Usage",
            description: "blablabla"
        }));
        process.exit();
    }
    return options;
}

function queryDocument(options) {
    var query = {
        "fieldA": {
            "$gte": options.paramA,
            "$lte": options.paramB
        }
    };
    if ("paramB" in options) {
        query.fieldB = { "$gte": option.paramB };
    }
    return query;
}
