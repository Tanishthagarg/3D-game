package Assignment1;
/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/
import java.util.ArrayList;

public class Player {
    private String name;
    private ArrayList<Card> cards=new ArrayList<>();

    public Player(String name,ArrayList<Card>cards){
        this.name=name;
        this.cards=cards;
    }

    public Card removeCard(){
        Card c= cards.get(0);
        cards.remove(c);
        return c;
    }

    public String getName() {
        return name;
    }

    public ArrayList<Card> getCards() {
        return cards;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setCards(ArrayList<Card> cards) {
        this.cards = cards;
    }

    public String toString(){
        StringBuilder sb=new StringBuilder(name+"'s hand [");
        //System.out.print(name+"'s hand [");
        for (Card c :
                cards) {
            sb.append(c);
            sb.append(", ");
           // System.out.print(c+", ");

        }
        sb.delete(sb.length()-2,sb.length());
        sb.append("]");

        return sb.toString();
    }
}
