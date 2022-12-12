clear variables; clc;

s = load("lab8_3.mat");

% id = struct("output",s.id.OutputData,"input",s.id.InputData,"t",length(s.id.InputData));
% val = struct("output",s.val.OutputData,"input",s.val.InputData,"t",length(s.val.InputData));

alpha = 0.2; % we choose a value between 0.01 and 0.5

figure,
subplot(211); plot(s.id.y); title("Identification output");
subplot(212); plot(s.val.y); title("Validation output");
