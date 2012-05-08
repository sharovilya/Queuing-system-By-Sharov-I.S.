// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

namespace SMO.Math

/// This is a sample module to contain functions and values
module SampleModule = 
     /// This is a sample value
     let sampleValue = 7 + 10

     /// This is a sample function
     let sampleFunction argument1 argument2 = 
         argument1 + argument2 

/// This is a sample class type
type SampleLibraryClassType(argument1: int, argument2: int) = 
    
    // This computes the maximum element when the object is constructed
    let maximumElement = max argument1 argument2
    
    /// Get the obejct arguments as a list
    member x.GetElements() = [argument1;  argument2]

    /// Get the sum of the two object arguments
    member x.Sum = argument1 + argument2

    /// Get the maximum of the two object arguments
    member x.Maximum = maximumElement

    /// Create an instance of the class type
    static member Create() = SampleLibraryClassType(3, 4)

