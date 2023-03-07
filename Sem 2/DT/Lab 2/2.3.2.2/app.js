var app = new Vue({
  el: '#app',
  data: {
    users: [],
    usersService: null
  },
  created: function() {
    usersService = users();
    usersService.get().then(reponse => (this.users = response.data));
  },
  methods: {}
})
