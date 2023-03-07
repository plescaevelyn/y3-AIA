var socket = io.connect('localhost:8000');

try {
  socket.on('connect', function(data) {
    socket.emmit("message-from-client", "Hello to everyone from " + checkBrowser());
  });

  socket.on('connect', function(data) {
    socket.emmit("message-from-server", function(message) {
      console.log(message);
    };
  });
}

catch(err) {
  alert('ERROR: socket.io encountered a problem:\n\n' + err);
}

function checkBrowser() {
  var browser = 'Noname browser';
  if (navigator.userAgent.search("Chrome") > -1) {
    browser = "Chrome";
  }

  if (navigator.userAgent.search("Firefox") > -1) {
    browser = "Firefox";
  }

  if (navigator.userAgent.search("Brave") > -1) {
    browser = "Brave";
  }

  return browser;
}

document.getElementById("send").addEventListener("click", sendMessage);

function sendMessage() {
  var message = document.getElementById("message").value;
  socket.emit("message-from-client", message);
}
