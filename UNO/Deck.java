package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/
import java.util.*;

public class Deck {
    SingularlyLinkedList<Card> Cards = new SingularlyLinkedList<>();
    SingularlyLinkedList<Card> shuffleCards = new SingularlyLinkedList<>();


    public Deck() {
        Face[] face = Face.values();
        Colour[] colour = Colour.values();
        //Creating deck of cards
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 12; j++) {
                Colour c = colour[i];
                Face f = face[j];
                Card cd = new Card(c, f);
                Cards.addFirst(cd);
                Cards.addFirst(cd);

            }
        }
        for (int z = 0; z < 4; z++) {
            Card cd = new Card(colour[4], face[12]);
            Cards.addFirst(cd);
        }
    }

    //method to shuffle the deck
    public void Shuffle() {
        Random rand = new Random();
        SingularlyLinkedList<Card> halfDeck1 = new SingularlyLinkedList<>();
        SingularlyLinkedList<Card> halfDeck2 = new SingularlyLinkedList<>();
        int r= (rand.nextInt(100)+1)*10;          //random number r so that deck shuffles random number of times
        for (int q = 0; q < r; q++) {
            for (int i = 0; i < 50; i++) {               //cutting the deck in half
                halfDeck1.addLast(Cards.removeFirst());    //first half
            }
            for (int i = 0; i < 50; i++) {
                halfDeck2.addLast(Cards.removeFirst());     //second half
            }
            while(Cards.size()!=100) {
                int ran1=rand.nextInt(5)+1;         //random ran1(belonging from 1 to 5) so that random number to cards get riffle in the deck
                for (int i = 0; i < ran1; i++) {
                    if(halfDeck1.isEmpty())
                        break;
                    Cards.addLast(halfDeck1.removeFirst());
                }
                int ran2=rand.nextInt(5)+1;
                for (int j = 0; j < ran2; j++) {
                    if(halfDeck2.isEmpty())
                        break;
                    Cards.addLast(halfDeck2.removeFirst());
                }

            }
        }
    }

    public Card deal() {
        return Cards.removeFirst();
    }

    /*this method is just for me to check if the deck is created correctly or not
    public void show(){
        System.out.println(Cards.size());
        while (!Cards.isEmpty()){
            System.out.println(Cards.removeFirst());
         }
        }*/
}


