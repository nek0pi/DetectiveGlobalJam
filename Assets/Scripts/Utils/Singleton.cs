using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>, new()
{
    private static StringBuilder s_builder = new StringBuilder();
    private static string s_typeString = typeof( T ).ToString();
    private static T instance;
	
    
    public static T Instance {
        get {
            if( instance != null ) { return instance; }
			
            var behaviour = System.Attribute.GetCustomAttribute( typeof( T ), typeof( SingularBehaviour ) ) as SingularBehaviour;
            if( behaviour == null ) {
                behaviour = SingularBehaviour.Default;
                _logWarning( "Behaviour is not defined! Consider using [SingularBehaviour] attribute; using Default for now" );
            }
			
            var foundInstances = FindObjectsOfType<T>();
            if( foundInstances.Length == 0 ) {
                if( behaviour.SpawnIfMissing ) {
                    instance = _SpawnInstance();
                }
                else {
                    _logWarning( "No instances found, strategy is 'Don't spawn if missing'. Things will break" );
                }
            }
            else if( foundInstances.Length == 1 ) {
                instance = foundInstances[0];
            }
            else {
                _logWarning( "More than one. Will try to not fail by using the first one" );
                instance = foundInstances[0];
            }
			
            if( behaviour.DontDestroy && (instance != null) ) {
                DontDestroyOnLoad( instance.gameObject );
            }
			
            return instance;
        }
    }

    #region Internals
    protected static void _log( string message ) {
        var formatted = _FormatMessage( message );
        Debug.Log( formatted, instance );
    }
	
    protected static void _logWarning( string message ) {
        var formatted = _FormatMessage( message );
        Debug.LogWarning( formatted, instance );
    }
	
    protected static void _logError( string message ) {
        var formatted = _FormatMessage( message );
        Debug.LogError( formatted, instance );
    }
    #endregion
	
	
    #region Private
    private static T _SpawnInstance() {
        var holder = new GameObject( s_typeString );
        return holder.AddComponent<T>();
    }
	
    private static string _FormatMessage( string message ) {
        s_builder.Length = 0;
		
        s_builder.Append( "[" );
        s_builder.Append( s_typeString );
        s_builder.Append( "] " );
        s_builder.Append( message );
		
        return s_builder.ToString();
    }
    #endregion
}

[System.AttributeUsage( System.AttributeTargets.Class, Inherited = false )]
public class SingularBehaviour : System.Attribute {
    public bool SpawnIfMissing { get; private set; }
    public bool DontDestroy { get; private set; } = true;
    public bool SearchInactive { get; private set; }
	
    public static SingularBehaviour Default {
        get {
            return new SingularBehaviour( false, false, false );;
        }
    }
	
    public SingularBehaviour( bool spawnIfMissing, bool dontDestroy, bool searchInactive ) {
        SpawnIfMissing = spawnIfMissing;
        DontDestroy = dontDestroy;
        SearchInactive = searchInactive;
    }
}