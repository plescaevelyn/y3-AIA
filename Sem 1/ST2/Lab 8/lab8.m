clc; clear variables;

%% Method I of plotting a circle
Mp = 10^(1/10);

radius = Mp/(Mp^2-1);
center = [-Mp^2/(Mp^2-1) 0];

figure,
viscircles(center,radius); grid;
%% Method II of plotting a circle
MdB = 2; % modulul in decibeli

figure,
cm(MdB); 
%% 
k = 1.5
H = k*9e4*tf(1,[1 135 0]);

figure,
nyquist(H); % open-loop Nyquist diagram
hold on;
cm(4); grid; shg; 
axis([-3 0 -2 3])
%%
MdB = 7.2
figure,
nyquist(H); % open-loop Nyquist diagram
hold on;
cm(MdB); grid; shg; 
axis([-3 0 -2 3]);

figure,
step(feedback(H,1)); grid; shg;