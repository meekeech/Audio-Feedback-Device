function [time,maxForce] = BigSubplotM()

clear

%Alex First experiment
% TrialName = ["Trial2" "Trial4" "Trial5"... 
%              "Trial6" "Trial7" "Trial8" "Trial9" "Trial10"...  
%              "Trial11" "Trial12" "Trial13" "Trial14" "Trial15"...  
%              "Trial16" "Trial17" "Trial18" "Trial19" "Trial20"...
%              "Trial21" "Trial22" "Trial23" "Trial24" "Trial25"];
%              "Trial26" "Trial27" "Trial28" "Trial29" "Trial30"];

%General
% TrialName = ["Trial1" "Trial2" "Trial3" "Trial4" "Trial5"... 
%              "Trial6" "Trial7" "Trial8" "Trial9" "Trial10"...  
%              "Trial11" "Trial12" "Trial13" "Trial14" "Trial15"...  
%              "Trial16" "Trial17" "Trial18" "Trial19" "Trial20"...
%              "Trial21" "Trial22" "Trial23" "Trial24" "Trial25"];
%              "Trial26" "Trial27" "Trial28" "Trial29" "Trial30"];



%findpeaks
% TrialName = ["JoeTrial1" "JoeTrial2" "JoeTrial3" "JoeTrial4" "JoeTrial5"... 
%              "JoeTrial6" "JoeTrial7" "JoeTrial8" "JoeTrial9" "JoeTrial10"...  
%              "JoeTrial11" "JoeTrial12" "JoeTrial13" "JoeTrial14" "JoeTrial15"...  
%              "JoeTrial16" "JoeTrial17" "JoeTrial18" "JoeTrial19" "JoeTrial20"...
%               "JoeTrial21" "JoeTrial22" "JoeTrial23" "JoeTrial24" "JoeTrial25"];
% %                "Trial26" "Trial27" "Trial28" "Trial29" "Trial30"];

TrialName = ["GraceTrial1" "GraceTrial2" "GraceTrial3" "GraceTrial4" "GraceTrial5"... 
             "GraceTrial6" "GraceTrial7" "GraceTrial8" "GraceTrial9" "GraceTrial10"...  
             "GraceTrial11" "GraceTrial12" "GraceTrial13" "GraceTrial14" "GraceTrial15"...  
             "GraceTrial16" "GraceTrial17" "GraceTrial18" "GraceTrial19" "GraceTrial20"...
             "GraceTrial21" "GraceTrial22" "GraceTrial23" "GraceTrial24" "GraceTrial25"... 
             "GraceTrial26" "GraceTrial27" "GraceTrial28" "GraceTrial29" "GraceTrial30"];
         
minPeakProm = 0.1;         
minPeakWidth = 0.1;
         
 figure
 sgtitle('P5 Force Data')

%Need bioinformatics toolsbox for this
% suptitle(strcat(forceType,' Axis'))

threshMax = 0.8;
threshAvg = 0.2;    
axisTop = 3;
axisBot = 0;

for i = 1:length(TrialName)
    forces = load(TrialName(i));
    forces = forces.ans;
    subplot(6,5,i)
   

    force_M(1,:) = forces(1,:);  
    force_M(2,:) = sqrt(forces(2,:).^2 + forces(3,:).^2 + forces(4,:).^2);

    %peak calculations
%     [pks1,locs1] = findpeaks(force_M(2,:),force_M(1,:),'MinPeakProminence',minPeakProm,'MinPeakWidth',minPeakWidth);
%     [pksPos,locsPos] = MakePositive(pks1,locs1);
%     pksTotal(i) = length(pksPos);

    plot(force_M(1,:),force_M(2,:))
    xlabel('Time (s)')
    ylabel('Force (N)')
    %title(TrialName(i));
%     scatter(locsPos,pksPos,'r'), hold off
    axis([0 forces(1,size(forces,2)) 0 3])
    
   % [maxSamples(i),maxForce(i)] = MaxCalculator(force_M,0.8);
%     meanValue(i) = MeanCalculator(force_M,threshAvg);   
%     axis([0 forces(1,size(forces,2)) axisBot axisTop])
   % time(i) = maxSamples(i)/1000;

%     text(2,2.8,sprintf('Over = %.2f%% > %.2f',time(i),threshMax))
%     text(2,2.4,sprintf('Avg = %.2f > %.2f',meanValue(i),threshAvg))
%     text(2,2.0,sprintf('Max = %.2f',maxForce(i)))
%     text(2,1.6,sprintf('Peaks = %d',pksTotal(i)))    

    
    
    clear forces force_M
end
    %time = round(reshape(time,[5,5])',3);
%     meanValue = round(reshape(meanValue,[5,6])',3);
    %maxForce = round(reshape(maxForce,[5,5])',3);
%     pksTotal = reshape(pksTotal,[5,6])';
    
    %finalAverages = [mean(time,2) mean(maxForce,2)];
    %differences = diff(finalAverages);
    
    %time = time';
    %maxForce = maxForce';
end

