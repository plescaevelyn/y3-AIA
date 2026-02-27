var api = require('./api.js');
var users = require('./users.json');

api.get('/', function(request, response) {
  response.json("node.js backend");
});

api.get('/users', function(request, response) {
  response.json(users);
});

api.put('/users', function(request, response) {
  if (!request.body || typeof request.body !== 'object') {
    return response.status(400).json('Invalid user data');
  }
  users[users.length] = request.body;
  response.json('User was saved succesfully');
});

api.delete('/users/:index', function(request, response) {
  var index = parseInt(request.params.index, 10);
  if (isNaN(index) || index < 0 || index >= users.length) {
    return response.status(400).json('Invalid index');
  }
  users.splice(index, 1);
  response.json('User with index ' + index + ' was deleted');
});

api.listen(3000, function() {
  console.log('CORS=enables web server is listening on port 3000...');
});
