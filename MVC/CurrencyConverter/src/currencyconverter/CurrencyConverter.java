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
public class CurrencyConverter {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
         View theView = new View();
        Model theModel = new Model();
        Controller theControler = new Controller(theView,theModel);
        theView.setVisible(true);
    }
    
}
