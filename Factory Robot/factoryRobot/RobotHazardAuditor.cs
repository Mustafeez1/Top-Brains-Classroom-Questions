class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState){
        if(armPrecision < 0.0 || armPrecision > 1.0){
            throw new RobotSafetyException("Arm precision must be 0.0-1.0");
        }
        if(workerDensity< 1 || workerDensity > 20 ){
            throw new RobotSafetyException("Worker density must be 1-20");
        }
       

        double machineRiskFactor = 0.0;
        if(machineryState == "Worn"){
            machineRiskFactor = 1.3;
        }else if(machineryState == "Faulty"){
            machineRiskFactor = 2.0;
        }
        else if(machineryState == "Critical"){
            machineRiskFactor = 3.0;
        }else{
            throw new RobotSafetyException("Unsupported Machinery state");
        }
        double Hazard_risk = ((1.0-armPrecision) * 15.0 + (workerDensity * machineRiskFactor));
        return Hazard_risk;
    } 
}