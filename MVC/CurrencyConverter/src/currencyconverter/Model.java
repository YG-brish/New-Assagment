/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package currencyconverter;

/**
 *
 * @author Hp
 */
public class Model {
    private double calculationValue;
     public void BirrtoDollar(float birr){
        calculationValue = birr/27;
    }
    public void DollartoBirr(float dollar){
        calculationValue= dollar*27;
    }
    public double getCalculationValue(){
        return calculationValue;
    }
   
    
}
