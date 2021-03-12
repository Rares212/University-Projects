function [h, deltaPr, deltaSr] = findFilterRestrict(wp, ws, deltaP, deltaS)
    % Functia incearca sa caute un filtru optim in functie de cerintele de
    % proiectare, incercand sa minimizeze ordinul filtrului
    % Argumente: wp - frecventa de trecere
    %            ws - frecventa de stopare
    %            deltaP - abaterea maxima in banda de trecere
    %            deltaS - abaterea maxima in banda de stopare
    % Iesiri: h - filtrul proiectat
    %         deltaPr - abaterea in banda de trecere
    %         deltaSr - abaterea in banda de stopare
    
    % O lista cu ferestrele folosite in cautare
    % ordonate aproximativ in ordinea utilitatii lor pentru
    % a optimiza cautarea
    filters = ["blackman", "chebwin", "chebwin_low", "chebwin_high", "hamming",...
               "hanning", "kaiser", "kaiser_low", "kaiser_high", "tukey", ... 
               "tukey_low", "tukey_high", "lanzcos", "lanzcos_low", "lanzcos_high",...
               "triunghiular", "dreptunghiular"];
           
    % O incercare de a optimiza cautarea dand pondere mai mare valorilor
    % de mijloc ale wc
    %mid = (ws + wp) / 2;
    %left = flip(logspace(log10(mid), log10(wp), 25));
    %right = logspace(log10(mid), log10(ws), 25);
    %wcSearch = [left right(2:end)];
    
    % O cautare brute-force a filtrului cu M minim
    for MCurrent = 1 : 1 : 256
        for filterIndex = 1 : length(filters)
            
            % In toate situatiile de test incercate, wc optim a fost
            % intotdeauna foarte apropriat de valoarea de mijloc dintre wp
            % si ws, deci pentru a optimiza cautarea am omis incercarea de
            % a cauta si alte valori ale lui wc
            
            for wcCurrent = linspace(wp, ws, 9)
            %for wcCurrent = (ws + wp) / 2
            %for wcIndex = 1 : length(wcSearch)
                % Pentru unele valori ale lui M si ale ferestrei, functia fir1 nu poate
                % returna un filtru. Astfel, am pus cautarea intr-un bloc
                % try catch pentru a putea ignora valorile ale lui M care
                % nu returneaza un filtru
                try
                    filter = filters(filterIndex);
                    h = getFilter(MCurrent, wcCurrent / pi, filter);
                    [deltaPr, deltaSr] = maxDeltas(h, wp, ws);
                    if (deltaPr < deltaP && deltaSr < deltaS)
                        display("Filtrul a fost gasit:");
                        display("DeltaPr: " + deltaPr + ", DeltaSr: " + deltaSr); 
                        display("Window: " + filter + ", wc: " + wcCurrent / pi + "pi, M = " + MCurrent);
                        return
                    end
                catch
                    continue
                end
            end
        end
    end
    display("Nu a fost gasit un filtru care sa indeplineasca criteriile");
end

