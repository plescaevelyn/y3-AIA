% define the transfer function and plot the open loop Bode diagram
Hol = tf(12,[1 5 0],'IODelay',0.2);
bode(Hol); grid; shg; hold on;

% zoom the phase characteristic around -180 degrees
axis([1e-1, 1e2, -270, 0]);

% read the cutoff frequency from the Bode diagram
wc = 2.2;

% point out the cutoff frequency on magnitude characteristic
handles = findobj(gcf,'Type','axes');
axes(handles(2));
semilogx([1e-1,1e2],[0,0],'*--')
semilogx(wc,0,"pentagram",'LineWidth',4); text(wc,0,'\omega_c');

% read the phase of the open loop at the cutoff frequency
olphase = -137;
axes(handles(1));
semilogx([1e-1,1e2],[-180,-180],'*--');

% plot the phase margin
semilogx([wc,wc],[-180,olphase],'m^-'); text(wc,olphase,'\gamma_k = 41^\circ');

% read wpi from the phase characteristic 
wpi = 4.33;

% read mk from the phase characteristic
mk = -7.4;

% plot the gain margin
axes(handles(2));
semilogx([wpi wpi],[0,mk],'mv-'); text(wpi,mk,'m_k=-7.4dB');

% point out wpi on the phase characteristic 
axes(handles(1));
semilogx(wpi,-180,"pentagram",'LineWidth',4); text(wpi,-180,'\omega_{-\pi}') 

% zoom on the central decade
axis([1e0 1e1 -270 0]);
hold off;