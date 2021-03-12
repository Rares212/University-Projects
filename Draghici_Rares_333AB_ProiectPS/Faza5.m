%% Partea I
wc = 0.4 * pi;
M = 20;
K = (M - 1) / 2;
m = 0 : M - 1;
h_id = sin(wc .* (m - K)) ./ (pi * (m - K));
h_id = h_id';

w = blackman(M);
h = h_id .* w;
h = h / sum(h);

figure
subplot(3, 1, 1)
plot(h)
title("Raspunsul la impuls al filtrului");

[H, omega] = freqz(h);

subplot(3, 1, 2)
plot(omega, abs(H))
title("Raspuns adimensional")
subplot(3, 1, 3)
plot(omega, mag2db(abs(H)))
title("Raspuns in dB")
%% Partea II
wp = 0.85 * pi;
ws = 0.95 * pi;
deltaP = 0.05;
deltaS = 0.05;
[h, deltaPr, deltaSr] = findFilterNonstandard(wp, ws, deltaP, deltaS);
figure
plot(h)
freqz(h)