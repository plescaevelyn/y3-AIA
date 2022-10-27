%% Bode diagrams
clear variables;

H = tf(40,[1 0]);
bode(H); grid; shg;

w = logspace(0,3,1000);
bode(H,w); grid; shg;
%% Use lsim to simulate the response to u(t) and then notice the amplitude of the output, which must be 10 according to Bode
t = linspace(0,20);
u = sin(4*t);
lsim(H,u,t); grid; shg;
%% For what frequency (rad/sec) is the attenuation of -3dB? What does -3dB mean?
w = 56.6;
T = 2*pi/w;
u = sin(w*t);
lsim(H,u,t); grid; shg;
