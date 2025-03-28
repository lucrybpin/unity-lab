using System.Threading.Tasks;
using UnityEngine;

public interface IGameAction
{
    Task Execute(GameObject actor);
}
