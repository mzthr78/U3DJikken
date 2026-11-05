# UnityWorldSpaceButton

正しいかどうかはわからん。雰囲気でやってる。
  

以下、雑な説明だけどゆるして


- Canvas の Event Camera を指定
- Canvas に Graphic Raycaster を追加
![](https://github.com/mzthr78/UnityWorldSpaceButton/blob/master/image/Screenshot2026-07-29%2023.43.09.png)

- 対象を絞るためにここではTagを指定
![](https://github.com/mzthr78/UnityWorldSpaceButton/blob/master/image/Screenshot2026-07-29%2023.44.00.png)

あとはソースを見てね。MainCamera.cs と button.cs を見ればわかると思う。

~~でも正直World SpaceじゃなくてScreen Spaceにしたほうがゲーム上も使いやすいと思う。~~
World Spaceでもカメラの切り替えでいけるらしい。
