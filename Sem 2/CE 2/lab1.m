h1 = tf(15,[1 5 0]);
ts1 = 0.1;
ts2 = 1;
ts3 = 2;

h_zoh1 = c2d(h1,ts1,'zoh')
h_tustin1 = c2d(h1,ts1,'tustin')

h_zoh2 = c2d(h1,ts2,'zoh')
h_tustin2 = c2d(h1,ts2,'tustin')

h_zoh3 = c2d(h1,ts3,'zoh')
h_tustin3 = c2d(h1,ts3,'tustin')

figure,
subplot(311); step(feedback(h1,1)); title('Initial transfer function'); 
subplot(312); step(feedback(h_zoh1,1)); title('Zero Order Hold method'); 
subplot(313); step(feedback(h_tustin1,1)); title('Tustin method'); 

figure,
subplot(311); step(feedback(h1,1)); title('Initial transfer function'); 
subplot(312); step(feedback(h_zoh2,1)); title('Zero Order Hold method'); 
subplot(313); step(feedback(h_tustin2,1)); title('Tustin method'); 

figure,
subplot(311); step(feedback(h1,1)); title('Initial transfer function'); 
subplot(312); step(feedback(h_zoh3,1)); title('Zero Order Hold method'); 
subplot(313); step(feedback(h_tustin3,1)); title('Tustin method'); 