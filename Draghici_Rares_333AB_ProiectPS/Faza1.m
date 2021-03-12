clc
clear all
%% a
M = 16;

figure
subplot(4, 4, 1);
w = boxcar(M);
stem(w)
title("Dreptunghiulara")

subplot(4, 4, 2);
w = triang(M);
stem(w)
title("Triunghiulara")

subplot(4, 4, 3);
w = blackman(M);
stem(w)
title("Blackman")

subplot(4, 4, 4);
w = chebwin(M, 80);
stem(w)
title("Chebisev 80db")

subplot(4, 4, 5);
w = chebwin(M, 90);
stem(w)
title("Chebisev 90db")

subplot(4, 4, 6);
w = chebwin(M, 100);
stem(w)
title("Chebisev 100db")

subplot(4, 4, 7);
w = hamming(M);
stem(w)
title("Hamming")

subplot(4, 4, 8);
w = hanning(M);
stem(w)
title("Hanning")

subplot(4, 4, 9);
w = kaiser(M, 1);
stem(w)
title("Kaiser 1db")

subplot(4, 4, 10);
w = kaiser(M, 5);
stem(w)
title("Kaiser 5db")

subplot(4, 4, 11);
w = kaiser(M, 10);
stem(w)
title("Kaiser 10db")

subplot(4, 4, 12);
w = tukeywin(M, 0.3);
stem(w)
title("Tuckey 30%")

subplot(4, 4, 13);
w = tukeywin(M, 0.6);
stem(w)
title("Tuckey 60%")

subplot(4, 4, 14);
w = tukeywin(M, 1);
stem(w)
title("Tuckey 100%")

subplot(4, 4, 15);
w = lanzcos(M, 0.5);
stem(w)
title("Lanzcos 0.5")

subplot(4, 4, 16);
w = lanzcos(M, 2);
stem(w)
title("Lanzcos 2")

%% b
M = 16;

figure
subplot(4, 4, 1);
w = boxcar(M);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Dreptunghiulara")

subplot(4, 4, 2);
w = triang(M);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Triunghiulara")

subplot(4, 4, 3);
w = blackman(M);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Blackman")

subplot(4, 4, 4);
w = chebwin(M, 80);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Chebisev 80db")

subplot(4, 4, 5);
w = chebwin(M, 90);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Chebisev 90db")

subplot(4, 4, 6);
w = chebwin(M, 100);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Chebisev 100db")

subplot(4, 4, 7);
w = hamming(M);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Hamming")

subplot(4, 4, 8);
w = hanning(M);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Hanning")

subplot(4, 4, 9);
w = kaiser(M, 1);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Kaiser 1db")

subplot(4, 4, 10);
w = kaiser(M, 5);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Kaiser 5db")

subplot(4, 4, 11);
w = kaiser(M, 10);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Kaiser 10db")

subplot(4, 4, 12);
w = tukeywin(M, 0.3);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Tuckey 30%")

subplot(4, 4, 13);
w = tukeywin(M, 0.6);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Tuckey 60%")

subplot(4, 4, 14);
w = tukeywin(M, 1);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Tuckey 100%")

subplot(4, 4, 15);
w = lanzcos(M, 0.5);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Lanzcos 0.5")

subplot(4, 4, 16);
w = lanzcos(M, 2);
w = w / sum(w);
[W, om] = freqz(w);
plot(om, mag2db(abs(W)));
title("Lanzcos 2")