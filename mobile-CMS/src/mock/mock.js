import Mock from 'mockjs';

Mock.mock('http://localhost:8080/getlunbo',{
    data:{
        'status':0,
        'message':[
            {'url':'www.baidu.com',img:'https://pic4.zhimg.com/80/v2-e856770ef010c27b6af9b8506ff6d1ab_hd.jpg'},
            {'url':'www.google.com',img:'http://seopic.699pic.com/photo/50035/0520.jpg_wh1200.jpg'}
        ]
    }
})
