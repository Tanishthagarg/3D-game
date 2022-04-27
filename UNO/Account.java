package Assignment1;

public class Account {

        private Queue<Integer> shares;
        public Account(){shares=new ArrayQueue<>(); }
        public void buyShares(Queue<Integer>bp,int share,int price){
            for (int i = 0; i < share; i++) {
                shares.enqueue(price);
                bp.enqueue(price);
            }
        }
        public void sellShares(Queue<Integer>bp,int share,int price){
            int buyingcost=0;

            for (int i = 0; i < share; i++) {
                buyingcost+=bp.dequeue();
                shares.dequeue();
            }
            int lossGain=(share*price)-buyingcost;
            if(lossGain>=0){
                System.out.println("\nCapital gain: = $"+lossGain);
            }
            if(lossGain<0){
                System.out.println("\nCapital Loss: = $"+(lossGain*-1));

            }

        }
        public int getTotalValue(){
            int total=0;
            Queue<Integer> buffer=new ArrayQueue<>();             //to copy the Queue shares
            int size=shares.size();
            for (int i = 0; i < size; i++) {
                buffer.enqueue(shares.first());
                shares.dequeue();
            }
            for (int i = 0; i < size; i++) {
                total+=buffer.first();
                shares.enqueue(buffer.dequeue());

            }
            return total;
        }
        public int getTotalShares(){
            return shares.size();
        }


}
