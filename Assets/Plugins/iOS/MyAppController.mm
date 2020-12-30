#import <UIKit/UIKit.h>
#import "UnityAppController.h"

@interface MyAppController : UnityAppController
{
    
}

@end

@implementation MyAppController

// Use `60` instead of the default `30` for `Application.targetFrameRate = -1`
- (void) callbackFramerateChange: (int)targetFPS
{
    [super callbackFramerateChange: (targetFPS <= 0 ? 60 : targetFPS)];
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(MyAppController)