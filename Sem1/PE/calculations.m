% Project calculations
u1 = 220; % primary supply voltage
u21 = 14; % secondary nominal voltage
u22 = 44;
u23 = 44;
i21 = 6;
i22 = 2;
i23 = 2;


%% Line transformer design steps
p2 = u21*i21 + u22*i22 + u23*i23 % total power in the secondary winding
s2 = p2;
% we rounded p2 to 300 and chose the following values from the table
niu_tr = 0.93 % efficiency of the transformer
J = 1.25 % permissible current density

pg = p2/2*(1+1/niu_tr) % global power of the transformer
sfe = 1.1813*sqrt(pg*(1+niu_tr)/J/niu_tr)
B = 1.1 % rated value of induction
l = round(sqrt(sfe),1) % width of the sheet stack
l = 5 % standardized value of the sheet, chosen from the table
b = sfe/l % thickness of the sheet stack
b = round(1.1*b,2) % real thickness of the magnetic core
g = 0.35 % thickness of the laminated sheets
Nsheets = round(b*10/0.35) % number of the laminated sheets
sfe = round(l*b) % final value of the core section
lmed = 4*l + 2*b % medium length of a winding turn

% section area of the copper conductor for the secondary windings
scu21 = round(i21/J,2)
scu22 = round(i23/J,2)
scu23 = scu22

% winding diameters for the seconday windings
d21 = round(sqrt(4*scu21/pi),2)
d22 = round(sqrt(4*scu22/pi),2)
d23 = d22

i1 = round(pg/u1,2) % the current given for the primary winding
scu1 = round(i1/J,2) % section area of the copper conductor for the primary winding
d1 = round(sqrt(4*scu1/pi),2) % winding diameter for the primary winding

% MUST BE CHECKED!
% conductor diameters chosen for the secondary windings and the primary
% winding
d21 = 1.2
d22 = 1.4
d23 = 1.4
d1 = 1.2

f = 50 % line frequency
e = round(4.44*f*B*0.9*sfe/10000,2)

% the number of winding turns
% for the primary winding
w1 = round(u1/e) 
% for the secondary windings
w21 = round(u21/e)
w22 = round(u22/e)
w23 = w22

% resistances for the transformer windings
ro = 0.0172 % copper sensitivity
r1 = round(w1*ro*lmed/10/scu1,2)
r21 = round(w21*ro*lmed/10/scu21,2)
r22 = round(w22*ro*lmed/10/scu22,2)
r23 = r22

% the secondary overall winding resistances
r21 = round(r21 + r1*(w21/w1)^2,2)
r22 = round(r22 + r1*(w22/w1)^2,2)
r23 = r22

% the rated values of the load resistances
rs21 = round(u21/i21,2)
rs22 = round(u22/i22,2)
rs23 = rs22

% electromotive force generated in the secondary winding
e21 = round(w21/w1*u1,2)
e22 = round(w22/w1*u1,2)
e23 = e22

% actual value of the load voltage
u21 = round(e21-r21*i21,2)
u22 = round(e22-r22*i22,2)
u23 = u22

% increased no load electromotive force
e21 = w21*e
e22 = w22*e
e23 = w23*e

% the new number of winding turns
w21 = round(w21 + r21*i21/e)
w22 = round(w22 + r22*i22/e)
w23 = w22

%% Simplified design of low power line transformers using nonograms
p2 = u21*i21 + u22*i22 + u23*i23 % secondary windings total power
p = 1/niu_tr*p2 % overall power

Design of rectifier circuits
omega = 1.5 % safety factor

% voltage stress of the rectifiers
umax21 = round(sqrt(2)*u21,2)
umax22 = round(2*sqrt(2)*u22,2)
umax23 = umax22

% maximum voltage accepted by the reversed biased rectifiers
urev21 = round(1.5*sqrt(2)*u21)
urev22 = round(1.5*2*sqrt(2)*u22)
urev23 = urev22

% current stress of the rectifiers
i21stress = 1.05*i21
i22stress = 1.05*i22
i23stress = i22stress

k1 = 2 % the number of diodes working simultaneously in the circuit for the bridge rectifier
k2 = 1 % the number of diodes working simultaneously in the circuit for the single rectifier
rd = 0.25 % equivalent resistance of the diode

% "starting" currents
ip1 = round(sqrt(2)*u21/(rs21+k1*rd),2)
ip2 = round(sqrt(2)*u22/(rs22+k2*rd),2)
ip3 = ip2

id = 5

% initial charging time of capacitors
% deltat1 = round((r21 + k1*rd) * cf1,2)
% deltat2 = round((r22 + k2*rd) * cf2,2)
% delta3 = delta2

%% Design of the smoothing filter
p = 67 % ripple factor
% q - filtering coefficient

ud = 0.75 % rectifier voltage drop
u21bar = round(0.9*e21 - 2*ud,2)
u22bar = round(0.9*e22 - ud,2)
u23bar = u22bar

p0 = 8.9333

q = p/p0

% rectifier overall equivalent resistances
rrt1 = round(r21 + 1*rd,2)
rrt2 = round(r22 + 2*rd,2)
rrt3 = rrt2

% smoothing capacitor values
cf1 = round(1600*q*(rrt1+rs1)/rrt1/rs1,2)
cf2 = round(1600*q*(rrt2+rs22)/rrt2/rs22,2)
cf3 = cf2

rr1 = rrt1
r01 = rs1
w = 314
e01 = 1.41*e21 - 1*ud

rr2 = rrt2
r02 = rs22
e02 = 1.41*e22 - 2*ud

ku1 = u0/e01
ku2 = u0/e02

kr1 = rr1/r01
kr2 = rr2/r02
