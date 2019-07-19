//Can put in a round and its respective questions in it
[System.Serializable]
public class RoundData
{
	public string name;
	public int pointsAddedForCorrectAnswer;
	public QuestionData[] questions;
}