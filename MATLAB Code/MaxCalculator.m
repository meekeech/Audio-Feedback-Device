function [count,maxForce] = MaxCalculator(force,thresh)
%fMax = zeros(1,length(force.ans(1,:))); 
count = 0;
maxForce = 0;
    for i = 1:length(force(1,:))
      if (abs(force(2,i)) > thresh)
          count = count+1;
      end
      if (abs(force(2,i)) > maxForce)
          maxForce = abs(force(2,i+1));
      end  
    end
end

