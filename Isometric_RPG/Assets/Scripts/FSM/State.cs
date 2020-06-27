public interface State
{
    void Left(FSM fsm);
    void Right(FSM fsm);
    void Top(FSM fsm);
    void Down(FSM fsm);
    void BasicAttack(FSM fsm);
}