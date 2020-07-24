# AppSettingsConverter
ClientSide Blazorで作ったツールになります。

ローカルで動かすためにはClientSideBlazor用の開発環境が必要になるのでこちらを参考にしてください。
https://docs.microsoft.com/ja-jp/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio

Azure WebAppsのAppSettingsとローカル環境のloaclSettingsのフォーマット変換をするツールです。
シナリオ的にはWebAppsで設定されている設定情報をローカルに持ってきて動かしたい時にフォーマット変換するのがめんどくさいので作りました。

ClientSide Blazorで作成したのはブラウザ内で通信を発生せずに処理を完結させるためです。
AppSettingsの情報はセキュリティにかかる内容も多いですので。

VS CodeのAzure Extension使えば実現可能なのですが、あちらは設定情報のアップロードもできてしまうのでオペレーションミスを懸念して利用を控えています。

![画像１](https://github.com/kingkino/AppSettingsConverter/blob/master/01.png "画像１")

![画像２](https://github.com/kingkino/AppSettingsConverter/blob/master/02.png "画像２")

![画像３](https://github.com/kingkino/AppSettingsConverter/blob/master/03.png "画像３")
