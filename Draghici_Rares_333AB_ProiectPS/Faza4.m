wp = 0.3 * pi;
ws = 0.4 * pi;
deltaP = 0.05;
deltaS = 0.05;
[h, deltaPr, deltaSr] = findFilterRestrict(wp, ws, deltaP, deltaS);
freqz(h)