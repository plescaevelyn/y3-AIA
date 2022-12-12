%% Lab 6

load('lab6_3.mat')

xid = id.InputData;
yid = id.OutputData;
xval = val.InputData;
yval = val.OutputData;

subplot(411)
plot(xid);
subplot(412)
plot(yid);
subplot(413)
plot(xval);
subplot(414)
plot(yval);

na = 9;
nb = 9;
N = length(yid)
M = na+nb;

% IDENTIFICATION

phi_id = zeros(N,M)
 
 for i=1 :N 
     for j = 1:na
         if(i-j<=0)
             phi_id(i,j) = 0;
         else 
             phi_id(i,j) = -1*yid(i-j);
         end
     end

     for j=na+1:M
        if(i-j <=0)
            phi_id(i,j) = 0;
        else   
            phi_id(i,j) = xid(i-j);
        end
     end

     end
 

theta= phi_id\yid;

yhatid = phi_id*theta;

tid = 1:length(xid);

figure,
 plot(tid,yid,tid,yhatid)

% VALIDATION
N = length(xval);
phi_val = zeros(N,na)
 
 for i=1 :N 
     for j = 1:na
         if(i-j<=0)
             phi_val(i,j) = 0;
         else 
             phi_val(i,j) = -1*yval(i-j);
         end
     end

     for j=na+1:M
        if(i-j <=0)
            phi_val(i,j) = 0;
        else 
            phi_val(i,j) = xval(na+i-j);
        end
     end
 end
     

tval = 1:length(xval);


% SIMULATION

phi_sim = zeros(length(xval),M)
 yhatsim = zeros(length(xval),1)
 for i=2 :length(xval) 
     for j = 1:na
         if(i-j>0)
             phi_sim(i,j) = -1*yhatsim(i-j);
         else phi_sim(i,j) = 0;
         end
     end

     for j=(na+1):M
        if(na+i-j >0)
            phi_sim(i,j) = xval(na+i-j);
        else phi_sim(i,j) = 0;
        end
     end
     yhatsim(i) = phi_sim(i,:)*theta;
 end

theta = phi_val\yval;
 yhatsim = phi_sim*theta
 figure,

 plot(tval,yval,tval,yhatsim)

n = length(tid)
mse = (1 / n) * sum(((yval(1:n) - yhatid).^2))