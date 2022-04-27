package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/

public class As1PartA_Driver {
    public static void main(String[] args) {
        GameSim gs=new GameSim();
        //System.out.println("Enter your name");         //can ask the users to enter their name

        Player p1 = new Player("Simba", gs.distributeCards());
        Player p2 = new Player("Nala", gs.distributeCards());
        Player p3 = new Player("Timon", gs.distributeCards());
        Player p4 = new Player("Pumbaa", gs.distributeCards());

        gs.addPlayers(p1);
        gs.addPlayers(p2);
        gs.addPlayers(p3);
        gs.addPlayers(p4);

        System.out.println("\nLets Play UNO!!!" );

        gs.setFirstCard();
        gs.initiateGamePlay();
    }
}