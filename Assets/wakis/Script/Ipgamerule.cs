public interface Ipgamerule
{
    void pGame_Start_event();//event処理(return 0実行中,return 1実行終了)
    int pGame_Update_event();//event処理(return 0実行中,return 1実行終了)
}