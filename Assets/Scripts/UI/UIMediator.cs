using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMediator : SingletonMonoBehaviour<UIMediator>
{
	[SerializeField] private TitleUI _title;
	[SerializeField] private PlayUI _play;
	[SerializeField] private ResultUI _result;

	[SerializeField] private EggUI _egg;

	public void Send(UICommand command)
	{
		switch (command)
		{
			case TitleCommand titleCommand:
				_title.Recieve(titleCommand);
				break;

			case PlayCommand playCommand:
				_play.Receive(playCommand);
				break;

			case PlayScoreCommand playScoreCommand:
				_result.Receive(playScoreCommand);
				break;

			// case GatlingCommand gatlingCommand:
			// 	_play.Receive(gatlingCommand);
			// 	break;

			// case GreatCannonCommand greatCannonCommand:
			// 	_play.Receive(greatCannonCommand);
			// 	break;

			case TimeCommand timeCommand:
				_play.Receive(timeCommand);
				break;

			case ResultCommand resultCommand:
				_result.Receive(resultCommand);
				break;

			case EggCommand eggCommand:
				_egg?.Receive(eggCommand);
				break;
			
			default:
				Debug.LogWarning("UI Command が設定されていません．");
				break;
		}
	}
}
