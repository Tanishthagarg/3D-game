package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/

import java.util.ArrayList;
import java.util.Random;

public class GameSim {
    private CircularDoublyLinkedList<Player> players = new CircularDoublyLinkedList<>();
    private Deck d;
    private Card discardCard;
    private int direction = 1;                //to keep a track in which direction game is being played i have set an int where 1 means playing in forward direction and 2 means in backward;

    public GameSim() {
        d = new Deck();
        d.Shuffle();

    }

    public ArrayList<Card> distributeCards() {
        ArrayList<Card> cd = new ArrayList<>();
        for (int i = 0; i < 7; i++) {
            cd.add(d.deal());
        }
        return cd;
    }

    public void setFirstCard() {
        Card c = d.deal();

        //if first card is wild
        if(c.getFace().getvalue() == 12) {
            while (c.getFace().getvalue() == 12) {              //if second card is also wild and then maybe third is also wild
                System.out.println("First card was Wild.........Getting a new card to start the game");
                c = d.deal();
            }
            System.out.println("First card: \n" + c + "\n");
        }

        //if first card is skip
        if(c.getFace().getvalue()==10){
            System.out.println("First Card: \n"+c+"\nOOPPPPPPSSSS! "+players.first().getName()+" misses the first turn\n");
            players.rotateForward();
        }

        //if first card is reverse
        else if(c.getFace().getvalue()==11){
            System.out.println("First Card: \n"+c+"\nDirection Reversed!");
            players.rotateReverse();
            System.out.println(players.first().getName()+" starts the game\n");
            direction=2;
        }

        else System.out.println("First Card: \n"+c+"\n");
        discardCard = c;

    }

    public void addPlayers(Player p) {
        if (players.isEmpty()) players.addFirst(p);
        else players.addLast(p);
    }

    public void initiateGamePlay() {

        ArrayList<Card> cd;
        do {
            String CurrentPlayer=players.first().getName();            //head element in the CircularlyDLL
            System.out.println(players.first());
            cd = players.first().getCards();
            boolean PlayCardfound = false;                        //boolean for the cards in the hand can't be played

            for (Card c : cd) {
                if (discardCard.getColour() == c.getColour() || discardCard.getFace() == c.getFace()) {
                    cd.remove(c);
                    discardCard = c;
                    PlayCardfound = true;
                    break;
                }
            }

            //if playable card is found
            if (PlayCardfound) {
                System.out.println(CurrentPlayer + " plays " + discardCard+"\n");
                if(cd.size()==1) System.out.println(CurrentPlayer+" yells UNO!\n");
            }

            //if playable card is not found
            else if (!PlayCardfound) {
                boolean foundWild = false;               //boolean for Wild card is in the hand or no
                for (Card c : cd) {
                    //checking for Wild card
                    if (c.getFace().getvalue() == 12) {
                        playWild(c,players,cd,discardCard);
                        foundWild = true;
                        break;
                    }

                }
                if (!foundWild) {
                    //when playable card is not found and wild card is also not found the draw a new card from deck
                    Card newc = d.deal();
                    cd.add(newc);
                    System.out.println(players.first().getName() + " has no play, draws " + newc);

                    //if the drawn card is wild
                    if(newc.getFace().getvalue()==12){
                        playWild(newc,players,cd,discardCard);
                    }

                    //else ckecking if the drawn card is playable
                    else if (discardCard.getColour() == newc.getColour() || discardCard.getFace() == newc.getFace()) {      //checking if the new card could be played
                        cd.remove(newc);
                        discardCard = newc;
                        System.out.println(players.first().getName() + " plays " + discardCard+"\n");
                        if(cd.size()==1) System.out.println(CurrentPlayer+" yells UNO!\n");
                    }

                    //else tell that card cant be played
                    else System.out.println(players.first().getName() + " cant play it\n");
                }
            }

            //now checking if the card played by the current player is Skip
            if (discardCard.getFace().getvalue() == 10) {
                //checking the direction in which the game is being played at a given moment
                if (direction == 1) {
                    players.rotateForward();
                    System.out.println(players.first().getName() + " misses the turn" + "\n");

                    players.rotateForward();
                } else if (direction == 2) {
                    players.rotateReverse();
                    System.out.println(players.first().getName() + " misses the turn" + "\n");

                    players.rotateReverse();
                }
            }
            //checking if the card played is Reverse
            else if (discardCard.getFace().getvalue() == 11) {
                System.out.println(players.first().getName() + " reverse direction" + "\n");
                if (direction == 1) {
                    players.rotateReverse();
                    direction = 2;
                } else if (direction == 2) {
                    players.rotateForward();
                    direction = 1;
                }
            }
            else if (direction == 1) players.rotateForward();
            else if (direction == 2) players.rotateReverse();

            if(cd.size()==0) System.out.println(CurrentPlayer+" WINS");
        } while(!cd.isEmpty());
    }

    private static void playWild(Card c,CircularDoublyLinkedList<Player> players,ArrayList<Card> cd,Card discardCard ){
        System.out.println(players.first().getName() + " Plays " + c);
        cd.remove(c);
        Random random = new Random();
        Colour colorChange = cd.get(random.nextInt(cd.size())).getColour();
        System.out.println("Color in now " + colorChange+"\n");
        if(cd.size()==1) System.out.println(players.first().getName()+" yells UNO!\n");
        discardCard.setColour(colorChange);
        Face[] face = Face.values();
        discardCard.setFace(face[13]);       //face[12] is notaFace just made this value to play wild card correctly

    }
}

