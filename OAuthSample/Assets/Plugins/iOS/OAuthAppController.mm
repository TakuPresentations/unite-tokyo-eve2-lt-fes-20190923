#import "UnityAppController.h"

void UnitySendMessage(const char* objName, const char* methodName, const char* param);

@interface OAuthAppController : UnityAppController
@end

@implementation OAuthAppController
// iOS9以上のスキーム起動処理.
#if __IPHONE_OS_VERSION_MAX_ALLOWED >= 90000

-(BOOL) application:(nonnull UIApplication *)application openURL:(nonnull NSURL *)url options:(nonnull NSDictionary<NSString *,id> *)options {
    NSString* message = [url absoluteString];
    UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
    return YES;
}

#endif

// 通常のスキーム起動処理.
- (BOOL)application:(nonnull UIApplication *)application openURL:(nonnull NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation {
    NSString* message = [url absoluteString];
    UnitySendMessage("BrowserAuthorize", "OnOpenUrl", [message UTF8String]);
    return YES;
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(OAuthAppController)
