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

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class Controller  {
    private View theView;
    private Model theModel;
    public Controller( View theView, Model theModel){
        this.theView = theView;
        this.theModel = theModel;
        this.theView.addCalculationListener(new Birrtodollar());
       this.theView.subCalculationListener(new Dollartobirr());
        
    }

    class Birrtodollar implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            float birr, dollar=0;
            try{
                birr = theView.getFirstNumber();
               
                theModel.BirrtoDollar(birr);
                
                
               theView.setCalcSolution(theModel.getCalculationValue());
            }
            catch(NumberFormatException ex){
                    theView.displayErrorMessage("you need to enter a number");
                    }
           
       

    }
    }
    
    class Dollartobirr implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            float dollar, birr=0;
            try{
                dollar = theView.getFirstNumber();
               
                theModel.DollartoBirr(dollar);
                
                
               theView.setCalcSolution(theModel.getCalculationValue());
            }
            catch(NumberFormatException ex){
                    theView.displayErrorMessage("you need to enter a number");
                    }
           
       

    }
    }
}