# TinyChat
LANで使える複数対応チャットツールです。
# コマンド
ユーザー名重複チェック
CHECK_USERNAME,ユーザー名,END                
RETURN_CHECK_USERNAME,(TRUE|FALSE),END   

ユーザー名登録
REGIST_USERNAME,ユーザー名,END
RETURN_REGIST_USERNAME,(TRUE|FALSE),END

部屋情報
GET_ROOM_INFO,END 部屋情報の取得
RETURN_ROOM_INFO,(部屋ID,部屋名,人数,(メンバー,)+)+,END   

入室
ENTER_ROOM,部屋ID,ユーザー名,END             
RETURN_ENTER_ROOM,(TRUE|FALSE),部屋チャット,END      

退室
OUT_ROOM,ユーザー名,部屋ID,END
RETURN_OUT_ROOM,(TRUE|FALSE),END

部屋作成
CREATE_ROOM,部屋名,END
RETURN_CREATE_ROOM,(TRUE|FALSE),END

メッセージ送信
SEND_MESSAGE,ユーザー名,部屋ID,メッセージ内容,END
RETURN_SEND_MESSAGE,(TRUE|FALSE),END          

チャット取得
GET_CHAT,ユーザー名,部屋ID,END
RETURN_CHAT,(TRUE|FALSE),チャット,END
#画像
