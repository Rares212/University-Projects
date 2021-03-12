%% a1
% Caracteristica in frecventa logaritmica

M = 16;
wc = 0.4; % * pi

figure
subplot(4, 4, 1);
w = boxcar(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Dreptunghiulara")

subplot(4, 4, 2);
w = triang(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Triunghiulara")

subplot(4, 4, 3);
w = blackman(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Blackman")

subplot(4, 4, 4);
w = chebwin(M, 80);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Chebisev 80db")

subplot(4, 4, 5);
w = chebwin(M, 90);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Chebisev 90db")

subplot(4, 4, 6);
w = chebwin(M, 100);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Chebisev 100db")

subplot(4, 4, 7);
w = hamming(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Hamming")

subplot(4, 4, 8);
w = hanning(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Hanning")

subplot(4, 4, 9);
w = kaiser(M, 1);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Kaiser 1db")

subplot(4, 4, 10);
w = kaiser(M, 5);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Kaiser 5db")

subplot(4, 4, 11);
w = kaiser(M, 10);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Kaiser 10db")

subplot(4, 4, 12);
w = tukeywin(M, 0.3);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Tuckey 30%")

subplot(4, 4, 13);
w = tukeywin(M, 0.6);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Tuckey 60%")

subplot(4, 4, 14);
w = tukeywin(M, 1);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Tuckey 100%")

subplot(4, 4, 15);
w = lanzcos(M, 0.5);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Lanzcos 0.5")

subplot(4, 4, 16);
w = lanzcos(M, 2);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Lanzcos 2")


%% a2
% Caracteristica in frecventa adimensionala

M = 16;
wc = 0.4; % * pi

figure
subplot(4, 4, 1);
w = boxcar(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Dreptunghiulara")

subplot(4, 4, 2);
w = triang(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Triunghiulara")

subplot(4, 4, 3);
w = blackman(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Blackman")

subplot(4, 4, 4);
w = chebwin(M, 80);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Chebisev 80db")

subplot(4, 4, 5);
w = chebwin(M, 90);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Chebisev 90db")

subplot(4, 4, 6);
w = chebwin(M, 100);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Chebisev 100db")

subplot(4, 4, 7);
w = hamming(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Hamming")

subplot(4, 4, 8);
w = hanning(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Hanning")

subplot(4, 4, 9);
w = kaiser(M, 1);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Kaiser 1db")

subplot(4, 4, 10);
w = kaiser(M, 5);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Kaiser 5db")

subplot(4, 4, 11);
w = kaiser(M, 10);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Kaiser 10db")

subplot(4, 4, 12);
w = tukeywin(M, 0.3);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Tuckey 30%")

subplot(4, 4, 13);
w = tukeywin(M, 0.6);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Tuckey 60%")

subplot(4, 4, 14);
w = tukeywin(M, 1);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Tuckey 100%")

subplot(4, 4, 15);
w = lanzcos(M, 0.5);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Lanzcos 0.5")

subplot(4, 4, 16);
w = lanzcos(M, 2);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, abs(W));
title("Lanzcos 2")

%% b
wc = 0.4;

figure

subplot(3, 1, 1)
M = 16;
w = blackman(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Blackman | M = 16")

subplot(3, 1, 2)
M = 24;
w = blackman(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Blackman | M = 24")

subplot(3, 1, 3)
M = 32;
w = blackman(M);
w = w / sum(w);
h = fir1(M-1, wc, 'low', w);
[W, om] = freqz(h);
plot(om, mag2db(abs(W)));
title("Blackman | M = 32")