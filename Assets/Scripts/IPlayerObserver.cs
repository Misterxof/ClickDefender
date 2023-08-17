public interface IPlayerObserver
{
    void UpdateIt();
	
    void OnHealthDamage(float health);

    void OnXPChange(float expierence, float maxExpierence);
}
