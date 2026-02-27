var express = require('express');
var cors = require('cors');
var app = express();
var corsOptions = {
  origin: 'http://localhost:3000',
  optionsSuccessStatus: 200
};
app.use(cors(corsOptions));

var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({
  extended: true
}));
app.use(bodyParser.json());

exports.app = app;
